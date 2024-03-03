using Microsoft.AspNetCore.Identity;
using UMS.Infrastructure.DTOs;

namespace UMS.Infrastructure.Interfaces
{
    /// <summary>
    /// Represents a repository for user-related operations.
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="model">The <see cref="User"/> model representing the user to be added.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains an <see cref="IdentityResult"/> indicating the outcome of the operation.</returns>
        Task<IdentityResult> Add(User model);
    }
}