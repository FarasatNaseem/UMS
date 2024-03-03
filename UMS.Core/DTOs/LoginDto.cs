namespace UMS.Core.DTOs
{
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Represents the data transfer object (DTO) for user login information.
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Gets or sets the username for login.
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the password for login.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}