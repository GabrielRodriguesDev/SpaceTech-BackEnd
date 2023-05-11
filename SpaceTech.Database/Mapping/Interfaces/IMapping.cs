using Microsoft.EntityFrameworkCore;

namespace SpaceTech.Database.Mapping.Interfaces;
public interface IMapping
{
    void OnModelCreating(ModelBuilder modelBuilder);
}
