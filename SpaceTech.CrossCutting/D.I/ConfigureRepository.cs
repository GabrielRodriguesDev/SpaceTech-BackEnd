using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpaceTech.Database;
using SpaceTech.Database.Contexts;
using SpaceTech.Database.Repository;
using SpaceTech.Domain.Interfaces;
using SpaceTech.Domain.Interfaces.Repository;

namespace SpaceTech.CrossCutting.D.I;
public class ConfigureRepository
{
    public static void Confing(IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("Connection_db");

        #region Context And Transaction
        services.AddDbContext<SpaceTechContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        services.AddScoped<IUserRepository, UserRepository>();
    }
}
