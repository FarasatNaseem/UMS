namespace UMS.Infrastructure.Interfaces
{
    using UMS.Infrastructure.DTOs;
    public interface IAuthenticationRepository
    {
        Task<GenericResponse<LoginResponse>> Login(LoginDto model);
        Task Logout();
    }
}