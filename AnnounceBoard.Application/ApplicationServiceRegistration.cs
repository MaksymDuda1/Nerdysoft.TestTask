using AnnounceBoard.Application.Abstractions;
using AnnounceBoard.Application.Models;
using AnnounceBoard.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AnnounceBoard.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile.MappingProfile));
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped(typeof(Lazy<>), typeof(LazyInstance<>));
        services.AddScoped<IAnnouncementService, AnnouncementService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFileService, FileService>();
        
        return services;
    }
}