namespace UMS.Core.DTOs
{
    /// <summary>
    /// Represents the response data containing user information after a successful registration.
    /// </summary>
    public class RegistrationResponse
    {
        /// <summary>
        /// Gets or sets the username of the registered user.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the registered user.
        /// </summary>
        public string? Email { get; set; }
    }
}