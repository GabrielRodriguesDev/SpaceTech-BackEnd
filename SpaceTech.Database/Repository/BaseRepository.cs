using Dapper;
using Microsoft.EntityFrameworkCore;
using SpaceTech.Database.Contexts;
using SpaceTech.Domain.Entities;
using SpaceTech.Domain.Interfaces;
using SpaceTech.Domain.Interfaces.Repository;
using System.Data.Common;

namespace SpaceTech.Database.Repository;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected SpaceTechContext _context;

    protected DbSet<TEntity> _dbSet;

    protected DbConnection _connection;

    protected IUnitOfWork _uow;


    public BaseRepository(SpaceTechContext context, IUnitOfWork uow)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
        _connection = _context.Database.GetDbConnection();
        _uow = uow;
    }

    public Guid Create(TEntity entity)
    {
        _dbSet.Add(entity);
        return entity.Id;
    }

    public void Update(TEntity entity)
    {
        entity.setChangedAt();
        _dbSet.Update(entity);
    }

    public void Delete(Guid id)
    {
        _connection.Execute($@"DELETE FROM {typeof(TEntity).Name} WHERE Id = @Id", new { Id = id }, _uow.CurrentTransaction());
    }

    public TEntity Get(Guid id)
    {
        return _connection.QueryFirstOrDefault<TEntity>($"SELECT * FROM {typeof(TEntity).Name} WHERE Id = @Id", new { Id = id }, _uow.CurrentTransaction());
    }
}
