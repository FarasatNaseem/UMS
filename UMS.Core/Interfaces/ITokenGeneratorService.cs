/// <summary>
/// Represents a service for generating tokens.
/// </summary>
public interface ITokenGeneratorService
{
    /// <summary>
    /// Generates a token.
    /// </summary>
    /// <returns>A string representation of the generated token.</returns>
    string GenerateToken();
}