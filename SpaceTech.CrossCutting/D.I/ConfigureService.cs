using Microsoft.Extensions.DependencyInjection;
using SpaceTech.CrossCutting.Clients;
using SpaceTech.Domain.Interfaces.Clients;
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
        services.AddScoped<ISMSClient, SMSClient>();
    }
}
