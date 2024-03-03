namespace UMS.Core.Interfaces
{
    using UMS.Core.DTOs;

    /// <summary>
    /// Interface defining the contract for user-related operations in the UMS Core module.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers a new user based on the provided registration model.
        /// </summary>
        /// <param name="model">The registration data for the new user.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A generic response indicating the success or failure of the registration along with relevant information.</returns>
        Task<GenericResponse<RegistrationResponse>> Register(RegisterDto model, CancellationToken cancellationToken);
    }
}