namespace UMS.Core.Services
{
    using System;

    /// <summary>
    /// Service class responsible for generating authentication tokens in the UMS Core module.
    /// </summary>
    public class TokenGeneratorService : ITokenGeneratorService
    {
        /// <summary>
        /// Generates a base64-encoded token using a new GUID.
        /// </summary>
        /// <returns>A string representing the generated authentication token.</returns>
        public string GenerateToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}