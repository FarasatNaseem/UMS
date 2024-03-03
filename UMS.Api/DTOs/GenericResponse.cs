namespace UMS.Api.DTOs
{
    using System.Diagnostics.CodeAnalysis;
    /// <summary>
    /// Data Transfer Object (DTO) representing a generic response in the UMS API, with success status, message, and optional data.
    /// </summary>
    /// <typeparam name="T">The type of data included in the response.</typeparam>

    [ExcludeFromCodeCoverage]
    public class GenericResponse<T> where T : class
    {
        /// <summary>
        /// Gets or sets a value indicating whether the operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets a message providing additional information about the operation.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the data included in the response.
        /// </summary>
        public T? Data { get; set; }
    }
}