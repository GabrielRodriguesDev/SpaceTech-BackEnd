using SpaceTech.Domain.Commands;
using SpaceTech.Domain.Commands.UserConsumption;
using SpaceTech.Domain.Interfaces;
using SpaceTech.Domain.Interfaces.Repository;
using SpaceTech.Domain.Interfaces.Services;

namespace SpaceTech.Domain.Services;
public class UserConsumptionService : IUserConsumptionService
{
    private IUserConsumptionRepository userConsumptionRepository;
    private IUnitOfWork _uow;

    public UserConsumptionService(IUserConsumptionRepository userConsumptionRepository, IUnitOfWork uow)
    {
        this.userConsumptionRepository = userConsumptionRepository;
        _uow = uow;
    }

    public GenericCommandResult Create(CreateUserConsumptionCommand command)
    {
        command.Validate();
        if (command.Invalid) return new GenericCommandResult(false, "Ops! Something went wrong.", command.Notifications);

        return new GenericCommandResult(true, "User consumption sucessfully registered.");
    }
}
