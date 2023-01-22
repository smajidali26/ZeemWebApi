using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zeem.DomainContracts.ViewModel.Request.User;
using ZeemFacade.Infrastructure;

namespace ZeemWebApi.Controllers
{
    [Route("api/[controller]")]
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
        [HttpPost]
        public async Task RegisterUser(UserRegistration userRegistration)
        {
            await _zeemUserFacade.RegisterUser(userRegistration);
        }

        [HttpGet(template: "GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            return Ok( await _zeemUserFacade.GetUserById(userId));
        }
        #endregion

    }
}
