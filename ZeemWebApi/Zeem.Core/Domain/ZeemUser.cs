namespace Zeem.Core.Domain
{
    public class ZeemUser : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public bool EmailVerified { get; set; }

        public bool MobileNumberVerified { get; set; }

        public bool IsLocked { get; set; }

        public ZeemUserRole UserRole { get; set; }

    }
}
