namespace UMS.Core.Services
{
    using AutoMapper;
    using System.Threading;
    using System.Threading.Tasks;
    using UMS.Core.DTOs;
    using UMS.Core.Interfaces;
    using UMS.Infrastructure.Interfaces;

    /// <summary>
    /// Service class responsible for user-related operations in the UMS Core module.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The repository for user-related data access.</param>
        /// <param name="mapper">The AutoMapper instance for DTO mapping.</param>
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Registers a new user based on the provided registration model.
        /// </summary>
        /// <param name="model">The registration data for the new user.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A generic response indicating the success or failure of the registration along with relevant information.</returns>
        public async Task<GenericResponse<RegistrationResponse>> Register(RegisterDto model, CancellationToken cancellationToken)
        {
            // Map API-level DTO to Infrastructure DTO for database interaction
            var dbLayerUserModel = this._mapper.Map<UMS.Infrastructure.DTOs.User>(model);

            // Attempt to add the user to the repository
            var response = await _userRepository.Add(dbLayerUserModel);

            // Check if the user registration was successful
            if (response.Succeeded)
            {
                return new GenericResponse<RegistrationResponse>
                {
                    Success = true,
                    Message = $"User with the name {model.UserName} and email address {model.Email} is registered successfully",
                    Data = new RegistrationResponse
                    {
                        UserName = model.UserName,
                        Email = model.Email
                    }
                };
            }

            return new GenericResponse<RegistrationResponse>
            {
                Success = false,
                Message = $"User with the name {model.UserName} and email address {model.Email} can not be registered \n Reason(s): {string.Join(", ", response.Errors.Select(e => e.Description))}",
                Data = new RegistrationResponse
                {
                    UserName = model.UserName,
                    Email = model.Email
                }
            };
        }
    }
}