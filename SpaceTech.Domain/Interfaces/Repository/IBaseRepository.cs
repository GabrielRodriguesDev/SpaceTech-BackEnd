using SpaceTech.Domain.Entities;

namespace SpaceTech.Domain.Interfaces.Repository;
public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Guid Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(Guid id);
    TEntity Get(Guid id);
}

