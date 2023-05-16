using SpaceTech.Domain.Entities;
using SpaceTech.Domain.Queries.Params;
using SpaceTech.Domain.Queries.Result;

namespace SpaceTech.Domain.Interfaces.Repository;
public interface IUserRepository : IBaseRepository<User>
{
    bool ThereIsUserByEmail(string email);

    User GetUserByEmail(string email);

    UserFormQueryResult FormSearch(SearchFormParams searchFormParams);
}
