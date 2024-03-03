namespace UMS.Api.Extensions
{
    using AutoMapper;

    /// <summary>
    /// Extension methods for configuring and registering AutoMapper mappings in the UMS API.
    /// </summary>
    public static class MappingExtension
    {

        /// <summary>
        /// Registers the AutoMapper service for mapping between DTOs in the UMS API.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the IMapper service is added.</param>
        /// <returns>The modified <see cref="IServiceCollection"/> with the IMapper service registered.</returns>
        public static IServiceCollection RegisterMapperService(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(sp => new MapperConfiguration(cfg =>
            {
                // Register mappings between UMS.Api and UMS.Core DTOs and their reverse mappings
                cfg.CreateMap<UMS.Api.DTOs.RegisterDto, UMS.Core.DTOs.RegisterDto>().ReverseMap();
                cfg.CreateMap<UMS.Core.DTOs.RegisterDto, UMS.Infrastructure.DTOs.User>().ReverseMap();

                cfg.CreateMap<UMS.Api.DTOs.LoginDto, UMS.Core.DTOs.LoginDto>().ReverseMap();
                cfg.CreateMap<UMS.Core.DTOs.LoginDto, UMS.Infrastructure.DTOs.LoginDto>().ReverseMap();

                // Register a generic mapping for UMS.Core.DTOs.GenericResponse<> and UMS.Api.DTOs.GenericResponse<>
                cfg.CreateMap(typeof(UMS.Core.DTOs.GenericResponse<>), typeof(UMS.Api.DTOs.GenericResponse<>)).ReverseMap();

                // Register specific mapping for RegistrationResponse
                cfg.CreateMap<UMS.Core.DTOs.RegistrationResponse, UMS.Api.DTOs.RegistrationResponse>().ReverseMap();

                cfg.CreateMap<UMS.Core.DTOs.LoginResponse, UMS.Api.DTOs.LoginResponse>().ReverseMap();
                cfg.CreateMap<UMS.Core.DTOs.LoginResponse, UMS.Infrastructure.DTOs.LoginResponse>().ReverseMap();

            }).CreateMapper());

            return services;
        }
    }
}