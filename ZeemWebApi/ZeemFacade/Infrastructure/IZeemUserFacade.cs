using Zeem.DomainContracts.ViewModel.Request.User;
using Zeem.DomainContracts.ViewModel.Response;

namespace ZeemFacade.Infrastructure
{
    public interface IZeemUserFacade
    {
        Task RegisterUser(UserRegistration userRegistration);

        Task<string> AuthenticateUser(UserAuthentication userAuthentication);

        Task<UserResponse> GetUserById(int userId);
    }
}
