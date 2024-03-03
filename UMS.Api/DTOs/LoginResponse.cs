namespace UMS.Api.DTOs
{
    /// <summary>
    /// Represents the response containing user information after a successful login in the UMS API.
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// Gets or sets the authentication token generated after a successful login.
        /// </summary>
        public string? Token { get; set; }
    }
}