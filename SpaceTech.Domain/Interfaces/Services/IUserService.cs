using SpaceTech.Domain.Commands;
using SpaceTech.Domain.Commands.User;

namespace SpaceTech.Domain.Interfaces.Services;
public interface IUserService
{
    GenericCommandResult Create(CreateUserCommand command, CancellationToken cancellationToken);
    GenericCommandResult Update(UpdateUserCommand command, CancellationToken cancellationToken);

}
