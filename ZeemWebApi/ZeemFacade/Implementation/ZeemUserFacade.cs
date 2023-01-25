using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zeem.Core;
using Zeem.Core.Domain;
using Zeem.Core.Exception;
using Zeem.Core.Infrastructure;
using Zeem.DomainContracts.ViewModel.Request.User;
using Zeem.DomainContracts.ViewModel.Response;
using Zeem.Service.Infrastructure;
using ZeemFacade.Framework.Extensions;
using ZeemFacade.Infrastructure;

namespace ZeemFacade.Implementation
{
    public class ZeemUserFacade : IZeemUserFacade
    {
        #region Members

        private readonly IZeemUserService _zeemUserService;

        private readonly IZeemRoleService _zeemRoleService;

        private readonly IZeemUserRoleService _zeemUserRoleService;

        private readonly IHeaderValue _headerValue;

        private readonly ZeemConfig _zeemConfig;

        #endregion

        #region Ctor

        public ZeemUserFacade(IHeaderValue headerValue, ZeemConfig zeemConfig, IZeemUserService zeemUserService
            , IZeemRoleService zeemRoleService , IZeemUserRoleService zeemUserRoleService)
        {
            _zeemConfig = zeemConfig;
            _headerValue = headerValue;
            _zeemUserService = zeemUserService;
            _zeemRoleService = zeemRoleService;
            _zeemUserRoleService = zeemUserRoleService;
        }

        #endregion

        public async Task RegisterUser(UserRegistration userRegistration)
        {
            
            if (userRegistration == null)
                throw new ArgumentNullException(nameof(userRegistration));

            if (!userRegistration.Password.Equals(userRegistration.ConfirmedPassword))
                throw new ZeemValidationException("Password and Confirm password does not match.", (int)ErrorCode.UserRegistration_Password_Not_Matched);

            var predicate = PredicateBuilder.True<ZeemUser>();
            predicate = predicate.And(x => x.Email.Equals(userRegistration.Email));
            var dbEntity = await _zeemUserService.GetUser(predicate);

            if (dbEntity != null)
                throw new ZeemValidationException("Email already exist with another user.", (int)ErrorCode.UserRegistration_Email_Already_Exist);
            
            predicate = PredicateBuilder.True<ZeemUser>();
            predicate = predicate.And(x => x.Username.Equals(userRegistration.Username));
            dbEntity =  await _zeemUserService.GetUser(predicate);
            if (dbEntity != null)
                throw new ZeemValidationException("Username already exist with another user.", (int)ErrorCode.UserRegistration_Username_Already_Exist);

            var entity = userRegistration.ToEntity<ZeemUser>();

            entity.Password = CommonFunctions.GetHash(entity.Password);

            await _zeemUserService.CreateUser(entity);
            var userRole = new ZeemUserRole();
            userRole.UserId = entity.Id;
            userRole.CreatedBy = entity.CreatedBy;

            if (_headerValue.CurrentUser == null)  // When user is created through sign up form.
            {
                var selfRole = _zeemRoleService.GetSelfRegistrationRole();
                userRole.RoleId= selfRole.Id;
            }

            await _zeemUserRoleService.InsertUserRole(userRole);
            
        }

        public async Task<UserResponse> GetUserById(int userId)
        {
            var user = await _zeemUserService.GetUserById(userId);

            var token = GenerateJwtToken(user);
            return user.ToModel<UserResponse>();
        }


        #region Private Methods

        private string GenerateJwtToken(ZeemUser user)
        {
            // generate token that is valid for 2 hours
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_zeemConfig.SecretKeyForToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString())
                        , new Claim("firstname", user.FirstName)
                        , new Claim("lastname", user.LastName)
                        , new Claim("email", user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}
