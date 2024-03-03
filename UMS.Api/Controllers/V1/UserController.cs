namespace UMS.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using UMS.Core.Interfaces;

    /// <summary>
    /// Controller responsible for user-related operations in the UMS API.
    /// </summary>
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger">The logger for logging.</param>
        /// <param name="userService">The user service for handling user operations.</param>
        /// <param name="mapper">The AutoMapper instance for DTO mapping.</param>
        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
        {
            this._logger = logger;
            this._userService = userService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="model">The user registration data.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An <see cref="IActionResult"/> containing the registration response.</returns>
        /// <response code="200">The user was successfully registered.</response>
        /// <response code="400">The provided user registration data was invalid.</response>
        [HttpPost("register")]
        [ProducesResponseType(typeof(UMS.Api.DTOs.GenericResponse<UMS.Api.DTOs.RegistrationResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UMS.Api.DTOs.GenericResponse<UMS.Api.DTOs.RegistrationResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UMS.Api.DTOs.RegisterDto model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var coreRegisterDto = this._mapper.Map<UMS.Core.DTOs.RegisterDto>(model);

                var coreResponse = await this._userService.Register(coreRegisterDto, cancellationToken);

                var apiResponse = this._mapper.Map<UMS.Api.DTOs.GenericResponse<UMS.Api.DTOs.RegistrationResponse>>(coreResponse);

                if (apiResponse.Success)
                {
                    return Ok(JsonConvert.SerializeObject(apiResponse, Formatting.Indented));
                }
                else
                {
                    return BadRequest(JsonConvert.SerializeObject(apiResponse, Formatting.Indented));
                }
            }

            return BadRequest(JsonConvert.SerializeObject("Invalid Model", Formatting.Indented));
        }
    }
}