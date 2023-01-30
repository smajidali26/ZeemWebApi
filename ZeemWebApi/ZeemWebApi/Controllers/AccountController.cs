using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zeem.DomainContracts.ViewModel.Request.User;
using Zeem.DomainContracts.ViewModel.Response;
using ZeemFacade.Infrastructure;
using ZeemWebApi.Model;

namespace ZeemWebApi.Controllers
{
    [ApiController]
    public class AccountController : BaseApiController
    {
        #region Members

        private readonly IZeemUserFacade _zeemUserFacade;

        #endregion

        #region Ctor

        public AccountController(IZeemUserFacade zeemUserFacade) {
            _zeemUserFacade = zeemUserFacade;
        }

        #endregion

        #region Actions

        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public async Task RegisterUser(UserRegistration userRegistration)
        {
            await _zeemUserFacade.RegisterUser(userRegistration);
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<ActionResult> Authenticate(UserAuthentication userRegistration)
        {
            return Ok(new ServiceResponse<string>() {
                Model = await _zeemUserFacade.AuthenticateUser(userRegistration),
                Success = true
            });
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            return Ok(new ServiceResponse<UserResponse>()
            {
                Model = await _zeemUserFacade.GetUserById(userId),
                Success = true
            });
        }
        #endregion

    }
}
