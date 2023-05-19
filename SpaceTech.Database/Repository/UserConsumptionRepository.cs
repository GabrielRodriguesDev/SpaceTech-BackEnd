using SpaceTech.Database.Contexts;
using SpaceTech.Domain.Entities;
using SpaceTech.Domain.Interfaces;
using SpaceTech.Domain.Interfaces.Repository;

namespace SpaceTech.Database.Repository;
public class UserConsumptionRepository : BaseRepository<UserConsumption>, IUserConsumptionRepository
{
    public UserConsumptionRepository(SpaceTechContext context, IUnitOfWork uow) : base(context, uow)
    {
    }
}
