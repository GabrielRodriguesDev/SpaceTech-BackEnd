using SpaceTech.Domain.Commands;
using SpaceTech.Domain.Commands.UserConsumption;

namespace SpaceTech.Domain.Interfaces.Services;
public interface IUserConsumptionService
{
    GenericCommandResult Create(CreateUserConsumptionCommand command);
}
