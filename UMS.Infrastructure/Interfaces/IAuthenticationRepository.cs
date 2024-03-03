namespace UMS.Infrastructure.Interfaces
{
    using System.Threading.Tasks;
    using UMS.Infrastructure.DTOs;

    /// <summary>
    /// Represents a repository for authentication-related operations.
    /// </summary>
    public interface IAuthenticationRepository
    {
        /// <summary>
        /// Attempts to authenticate a user based on the provided login information.
        /// </summary>
        /// <param name="model">The <see cref="LoginDto"/> containing login information.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains a <see cref="GenericResponse{T}"/> with <see cref="LoginResponse"/> as data.
        /// </returns>
        Task<GenericResponse<LoginResponse>> Login(LoginDto model);

        /// <summary>
        /// Logs out the currently authenticated user.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Logout();
    }
}