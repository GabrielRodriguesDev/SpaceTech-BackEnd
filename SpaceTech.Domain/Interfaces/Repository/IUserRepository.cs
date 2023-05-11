using SpaceTech.Domain.Entities;

namespace SpaceTech.Domain.Interfaces.Repository;
public interface IUserRepository : IBaseRepository<User>
{
    bool ThereIsUserByEmail(string email);

    User GetUserByEmail(string email);
}
