namespace UMS.Api.DTOs
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Data transfer object (DTO) representing the login information in the UMS API.
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