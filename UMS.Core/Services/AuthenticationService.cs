namespace UMS.Core.Services
{
    using AutoMapper;
    using System;
    using System.Threading.Tasks;
    using UMS.Core.Interfaces;
    using UMS.Infrastructure.Interfaces;

    /// <summary>
    /// Service class for handling user authentication operations in the UMS Core module.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly ITokenGeneratorService _tokenGeneratorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for DTO mapping.</param>
        /// <param name="authenticationRepository">The repository for handling authentication operations.</param>
        /// <param name="tokenGeneratorService">The service for generating authentication tokens.</param>
        public AuthenticationService(IMapper mapper, IAuthenticationRepository authenticationRepository, ITokenGeneratorService tokenGeneratorService)
        {
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._authenticationRepository = authenticationRepository ?? throw new ArgumentNullException(nameof(authenticationRepository));
            this._tokenGeneratorService = tokenGeneratorService ?? throw new ArgumentNullException(nameof(tokenGeneratorService));
        }

        /// <summary>
        /// Handles user login based on the provided login model.
        /// </summary>
        /// <param name="model">The login model containing user credentials.</param>
        /// <returns>A generic response indicating the success or failure of the login operation along with relevant information.</returns>
        public async Task<UMS.Core.DTOs.GenericResponse<UMS.Core.DTOs.LoginResponse>> Login(UMS.Core.DTOs.LoginDto model)
        {
            // Map the Core LoginDto to Infrastructure LoginDto
            var dbLayerLoginDto = _mapper.Map<Infrastructure.DTOs.LoginDto>(model);

            // Call the authentication repository for login
            var response = await _authenticationRepository.Login(dbLayerLoginDto);

            if (response.Success)
            {
                // If login is successful, map and generate token
                var data = this._mapper.Map<UMS.Core.DTOs.LoginResponse>(response.Data);
                data.Token = _tokenGeneratorService.GenerateToken();

                return new UMS.Core.DTOs.GenericResponse<UMS.Core.DTOs.LoginResponse>
                {
                    Success = true,
                    Message = "User exists and logged in successfully",
                    Data = data
                };
            }

            // If login fails, return a failure response with the appropriate message
            return new UMS.Core.DTOs.GenericResponse<UMS.Core.DTOs.LoginResponse>
            {
                Success = false,
                Message = response.Message,
                Data = this._mapper.Map<UMS.Core.DTOs.LoginResponse>(response.Data)
            };
        }

        /// <summary>
        /// Handles user logout (not implemented in this version).
        /// </summary>
        /// <returns>A task representing the asynchronous logout operation.</returns>
        public Task Logout()
        {
            // Logout functionality not implemented in this version
            throw new NotImplementedException();
        }
    }
}