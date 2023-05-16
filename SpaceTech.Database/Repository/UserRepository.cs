using Dapper;
using SpaceTech.Database.Contexts;
using SpaceTech.Domain.Entities;
using SpaceTech.Domain.Interfaces;
using SpaceTech.Domain.Interfaces.Repository;
using SpaceTech.Domain.Queries;
using SpaceTech.Domain.Queries.Params;
using SpaceTech.Domain.Queries.Result;

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

    public UserFormQueryResult FormSearch(SearchFormParams searchFormParams)
    {
       return _connection.QueryFirstOrDefault<UserFormQueryResult>(BaseQueries.SearchForm(searchFormParams), searchFormParams, _uow.CurrentTransaction());
    }

    public IEnumerable<UserListResult> Search(SearchParams searchParams)
    {
        return _connection.Query<UserListResult>(BaseQueries.Search(searchParams), searchParams, _uow.CurrentTransaction());
    }

    public int Totalizer(SearchParams searchParams)
    {
        return _connection.QueryFirstOrDefault<int>(BaseQueries.Search(searchParams, true), searchParams, _uow.CurrentTransaction());
    }
}
