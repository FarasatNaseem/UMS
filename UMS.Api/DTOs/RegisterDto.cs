namespace UMS.Api.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Data Transfer Object (DTO) representing the registration information for a new user in the UMS API.
    /// </summary>

    [ExcludeFromCodeCoverage]
    public class RegisterDto
    {
        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Full name must be between 2 and 100 characters.")]
        public string? FullName { get; set; }

        /// <summary>
        /// Gets or sets the username for the new user.
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 25 characters.")]
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the password for the new user.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, MinimumLength = 12, ErrorMessage = "Password must be between 12 and 50 characters.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the role ID associated with the new user.
        /// </summary>
        [Required(ErrorMessage = "Role ID is required.")]
        public int RoleId { get; set; }
    }
}