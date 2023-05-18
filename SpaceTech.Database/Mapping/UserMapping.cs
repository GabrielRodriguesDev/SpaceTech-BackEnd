using Microsoft.EntityFrameworkCore;
using SpaceTech.Database.Mapping.Interfaces;
using SpaceTech.Domain.Entities;

namespace SpaceTech.Database.Mapping;
public class UserMapping : BaseMapping<User>, IMapping
{
    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        entity.Property(a => a.Name).HasColumnType("varchar(120)");
        entity.Property(a => a.Surname).HasColumnType("varchar(220)");
        entity.Property(a => a.Email).HasColumnType("varchar(120)");
        entity.HasIndex(a => a.Email).HasDatabaseName("unq1_User").IsUnique();
        entity.Property(a => a.Telephone).HasColumnType("varchar(11)");
        entity.Property(a => a.VerificationCode).HasColumnType("varchar(5)");

        #region Comments
        entity.Property(t => t.Name).HasComment("Name.");
        entity.Property(t => t.Surname).HasComment("Surname.");
        entity.Property(t => t.Email).HasComment("E-mail.");
        entity.Property(t => t.Password).HasComment("Password.");
        entity.Property(t => t.Telephone).HasComment("Telephone.");
        entity.Property(t => t.VerificationCode).HasComment("VerificationCode.");
        #endregion
    }
}
