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

        #endregion

        #region Ctor

        public ZeemUserFacade(IZeemUserService zeemUserService, IZeemRoleService zeemRoleService
            , IZeemUserRoleService zeemUserRoleService)
        {
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

            var selfRole = _zeemRoleService.GetSelfRegistrationRole();

            var userRole = new ZeemUserRole()
            {
                UserId = entity.Id,
                RoleId = selfRole.Id,
                CreatedBy= entity.Id
            };

            await _zeemUserRoleService.InsertUserRole(userRole);
            
        }

        public async Task<UserResponse> GetUserById(int userId)
        {
            var user = await _zeemUserService.GetUserById(userId);
            return user.ToModel<UserResponse>();
        }
    }
}
