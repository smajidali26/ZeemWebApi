namespace Zeem.DomainContracts.ViewModel.Request.User
{
    public class UserAuthentication : BaseRequestEntityModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
