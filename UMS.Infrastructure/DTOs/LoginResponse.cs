namespace UMS.Infrastructure.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) for the response after a user login.
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
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
    }
}