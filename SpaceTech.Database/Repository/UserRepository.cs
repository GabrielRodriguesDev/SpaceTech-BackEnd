using Dapper;
using SpaceTech.Database.Contexts;
using SpaceTech.Domain.Entities;
using SpaceTech.Domain.Interfaces;
using SpaceTech.Domain.Interfaces.Repository;
using SpaceTech.Domain.Queries;

namespace SpaceTech.Database.Repository;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(SpaceTechContext context, IUnitOfWork uow) : base(context, uow)
    {
    }

    public bool ThereIsUserByEmail(string email)
    {
        return _connection.QueryFirstOrDefault<bool>(UserQueries.ThereIsUserByEmail(), new { Email = email }, _uow.CurrentTransaction());
    }

    public User GetUserByEmail(string email)
    {
        return _connection.QueryFirstOrDefault<User>(UserQueries.GetUserByEmail(), new { Email = email }, _uow.CurrentTransaction());
    }
}
