namespace UMS.Infrastructure.Repositories
{
    using Microsoft.AspNetCore.Identity;
    using UMS.Infrastructure.DTOs;
    using UMS.Infrastructure.Interfaces;

    /// <summary>
    /// Repository class for handling user authentication operations in the UMS Infrastructure module.
    /// </summary>
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationRepository"/> class.
        /// </summary>
        /// <param name="userManager">The UserManager for managing user-related operations.</param>
        /// <param name="signInManager">The SignInManager for handling user sign-in.</param>
        public AuthenticationRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        /// <summary>
        /// Handles user login based on the provided login model.
        /// </summary>
        /// <param name="model">The login model containing user credentials.</param>
        /// <returns>A generic response indicating the success or failure of the login operation along with relevant information.</returns>
        public async Task<GenericResponse<LoginResponse>> Login(LoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null || !user.IsActive)
            {
                return this.CreateFailureResponse("User doesn't exist or is not active");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);

            return result.Succeeded
                ? this.CreateSuccessResponse(user)
                : this.CreateFailureResponse("Invalid credentials");
        }

        /// <summary>
        /// Handles user logout (not implemented in this version).
        /// </summary>
        /// <returns>A task representing the asynchronous logout operation.</returns>
        public Task Logout()
        {
            throw new NotImplementedException();
        }

        private  GenericResponse<LoginResponse> CreateSuccessResponse(User user)
        {
            return new GenericResponse<LoginResponse>
            {
                Success = true,
                Message = "User login successful",
                Data = new LoginResponse
                {
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Id = user.Id,
                    Email = user.Email,
                    Role = Convert.ToString(user.RoleId)
                }
            };
        }

        private  GenericResponse<LoginResponse> CreateFailureResponse(string errorMessage)
        {
            return new GenericResponse<LoginResponse>
            {
                Success = false,
                Message = errorMessage,
                Data = null
            };
        }
    }
}
