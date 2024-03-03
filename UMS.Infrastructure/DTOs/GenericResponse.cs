namespace UMS.Infrastructure.DTOs
{
    /// <summary>
    /// Represents a generic response containing information about the success of an operation.
    /// </summary>
    /// <typeparam name="T">The type of data included in the response.</typeparam>
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
        /// Gets or sets the data associated with the response.
        /// </summary>
        public T? Data { get; set; }
    }
}