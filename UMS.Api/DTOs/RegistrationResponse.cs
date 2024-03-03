namespace UMS.Api.DTOs
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Data Transfer Object (DTO) representing the response to a user registration in the UMS API.
    /// </summary>

    [ExcludeFromCodeCoverage]
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