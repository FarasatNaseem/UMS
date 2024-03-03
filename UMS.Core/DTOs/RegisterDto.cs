namespace UMS.Core.DTOs
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterDto
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Full name must be between 2 and 100 characters.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 25 characters.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, MinimumLength = 12, ErrorMessage = "Password must be between 12 and 50 characters.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Role ID is required.")]
        public int RoleId { get; set; }
    }
}