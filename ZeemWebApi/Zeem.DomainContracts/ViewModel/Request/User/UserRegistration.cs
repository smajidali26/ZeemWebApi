using System.ComponentModel.DataAnnotations;

namespace Zeem.DomainContracts.ViewModel.Request.User
{
    public class UserRegistration : BaseRequestEntityModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string MobileNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string ConfirmedPassword { get; set; }

        /// <summary>
        /// When user is created through signup or self registration form, then this property will be null.
        /// </summary>
        public int? RoleId { get; set; }
    }
}
