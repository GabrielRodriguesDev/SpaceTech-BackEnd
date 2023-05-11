using System.Data;

namespace SpaceTech.Domain.Interfaces;
public interface IUnitOfWork
{
    void BeginTransaction();
    void Commit();
    void Rollback();
    IDbTransaction CurrentTransaction();
}
