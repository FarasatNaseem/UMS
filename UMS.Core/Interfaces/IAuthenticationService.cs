using UMS.Core.DTOs;

namespace UMS.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<GenericResponse<LoginResponse>> Login(LoginDto model);
        Task Logout();
    }
}
