namespace UMS.Api.DTOs
{
    /// <summary>
    /// Represents an error in the UMS API.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string? Message { get; set; }
    }
}