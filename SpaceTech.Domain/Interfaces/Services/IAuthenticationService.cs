using SpaceTech.Domain.Commands.Authentication;

namespace SpaceTech.Domain.Interfaces.Services;
public interface IAuthenticationService
{
    AuthenticationCommandResult Login(LoginCommand command, CancellationToken cancellationToken);
}
