using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpaceTech.Domain.Entities;

namespace SpaceTech.Database.Mapping;
public abstract class BaseMapping<TEntity> where TEntity : BaseEntity
{
    protected EntityTypeBuilder<TEntity> entity = null!;
    public virtual void OnModelCreating(ModelBuilder modelBuilder)
    {
        this.entity = modelBuilder.Entity<TEntity>();
        entity.ToTable(typeof(TEntity).Name).HasCharSet("utf8");
        entity.HasKey(t => t.Id);
        entity.Property(a => a.Id).HasColumnType("char(36)").IsRequired();

        #region  Comments
        entity.Property(t => t.Id).HasComment("Record identifier.");
        entity.Property(t => t.CreatedAt).HasComment("Record creation date and time.");
        entity.Property(t => t.ChangedAt).HasComment("Date and time of last record change.");
        #endregion
    }
}