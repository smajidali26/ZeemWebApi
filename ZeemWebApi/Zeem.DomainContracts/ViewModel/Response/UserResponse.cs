namespace Zeem.DomainContracts.ViewModel.Response
{
    public class UserResponse : BaseResponseEntityModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string Username { get; set; }

        public bool EmailVerified { get; set; }

        public bool MobileNumberVerified { get; set; }

        public bool IsLocked { get; set; }
    }
}
