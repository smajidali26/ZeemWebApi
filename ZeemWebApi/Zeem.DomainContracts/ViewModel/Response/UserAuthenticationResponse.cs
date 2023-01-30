namespace Zeem.DomainContracts.ViewModel.Response
{
    public class UserAuthenticationResponse : BaseEntityModel
    {
        public string Token { get; set; }

        public string Message { get; set; }
    }
}
