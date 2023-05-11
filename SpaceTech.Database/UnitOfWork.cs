using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SpaceTech.Database.Contexts;
using SpaceTech.Domain.Interfaces;
using System.Data;

namespace SpaceTech.Database;
public class UnitOfWork : IUnitOfWork
{
#nullable disable

    private DbContext _context;
    private IDbContextTransaction _dbContextTransaction;

    public UnitOfWork(SpaceTechContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        _dbContextTransaction = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        if (_dbContextTransaction is null)
            throw new Exception("Transação não inciada.");
        _context.SaveChanges();
        _dbContextTransaction.CommitAsync().Wait();
        _context.ChangeTracker.Clear();
        _dbContextTransaction = null!;
    }

    public void Rollback()
    {
        if (_dbContextTransaction is null)
            throw new Exception("Transação não inciada.");

        _dbContextTransaction.RollbackAsync().Wait();
    }

    public IDbTransaction CurrentTransaction()
    {
        IDbTransaction result = null!;

        if (_dbContextTransaction is not null)
            result = _dbContextTransaction.GetDbTransaction();

        return result;
    }
}

