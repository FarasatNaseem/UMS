using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UMS.Api.DTOs;
using UMS.Api.Helpers;
using UMS.Core.Interfaces;

namespace UMS.Api.Controllers
{
    /// <summary>
    /// Controller for handling user authentication operations.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="logger">The logger for logging.</param>
        /// <param name="authenticationService">The authentication service for handling login.</param>
        /// <param name="mapper">The AutoMapper instance for DTO mapping.</param>
        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService, IMapper mapper)
        {
            this._logger = logger;
            this._authenticationService = authenticationService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Handles user login.
        /// </summary>
        /// <param name="model">The login model containing user credentials.</param>
        /// <returns>Returns an IActionResult indicating the result of the login operation.</returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] // Swagger attribute for documenting the expected response type
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))] // Swagger attribute for documenting the expected response type
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))] // Swagger attribute for documenting the expected response type
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var coreLoginDto = this._mapper.Map<UMS.Core.DTOs.LoginDto>(model);

                    var coreResponse = await this._authenticationService.Login(coreLoginDto);

                    var apiResponse = this._mapper.Map<UMS.Api.DTOs.GenericResponse<UMS.Api.DTOs.LoginResponse>>(coreResponse);

                    if (apiResponse.Success)
                    {
                        return Ok(JsonConvert.SerializeObject(apiResponse, Formatting.Indented));
                    }
                    else
                    {
                        return BadRequest(JsonConvert.SerializeObject(apiResponse, Formatting.Indented));
                    }
                }
                catch (Exception ex)
                {
                    string message = $"An error occurred while login- " + ex.Message;

                    return StatusCode(StatusCodes.Status500InternalServerError, JsonConvert.SerializeObject(new Response
                    {
                        Success = false,
                        Message = $"An error occurred while login- " + ex.Message,
                        Error = new Error
                        {
                            Code = "Login Error",
                            Message = message
                        }
                    }, Formatting.Indented));

                }
            }

            return BadRequest(JsonConvert.SerializeObject(new Response
            {
                Success = false,
                Message = "Invalid input",
                Error = new Error
                {
                    Code = "Input not valid",
                    Message = ModelStateHelper.GetErrors(ModelState)
                }
            }, Formatting.Indented));

        }
    }
}