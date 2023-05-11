using Microsoft.Extensions.DependencyInjection;
using SpaceTech.Domain.Interfaces.Infrastructure;
using SpaceTech.Domain.Interfaces.Services;
using SpaceTech.Domain.Services;
using SpaceTech.Infrastructure.Errors;

namespace SpaceTech.CrossCutting.D.I;
public class ConfigureService
{
    public static void Confing(IServiceCollection services)
    {
        services.AddScoped<IErrorManager, ErrorManager>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}
