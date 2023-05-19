using Microsoft.EntityFrameworkCore;
using SpaceTech.Database.Mapping.Interfaces;
using SpaceTech.Domain.Entities;

namespace SpaceTech.Database.Mapping;
public class UserConsumptionMapping : BaseMapping<UserConsumption>, IMapping
{
    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        entity.Property(a => a.Url).HasColumnType("varchar(500)");

        #region Comments
        entity.Property(t => t.UserId).HasComment("User identifier.");
        entity.Property(t => t.Url).HasComment("Url consumed by API.");
        #endregion
    }
}
