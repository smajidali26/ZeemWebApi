using Zeem.DomainContracts.ViewModel.Request.User;
using Zeem.DomainContracts.ViewModel.Response;

namespace ZeemFacade.Infrastructure
{
    public interface IZeemUserFacade
    {
        Task RegisterUser(UserRegistration userRegistration);

        Task<UserResponse> GetUserById(int userId);
    }
}
