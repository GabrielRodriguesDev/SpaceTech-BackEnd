using Microsoft.EntityFrameworkCore;
using SpaceTech.Database.Mapping.Interfaces;
using System.Reflection;

namespace SpaceTech.Database.Contexts;
public class SpaceTechContext : DbContext
{
#nullable disable
    public SpaceTechContext(DbContextOptions<SpaceTechContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var typesToMapping =
        (
        from x in Assembly.GetExecutingAssembly().GetTypes()
        where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
        select x
        ).ToList();

        foreach (var mapping in typesToMapping)
        {
            IMapping mappingClass = Activator.CreateInstance(mapping) as IMapping;
            if (mappingClass != null)
                mappingClass.OnModelCreating(modelBuilder);
        }
    }
}
