using SpaceTech.Domain.Commands;
using SpaceTech.Domain.Commands.Authentication;

namespace SpaceTech.Domain.Interfaces.Services;
public interface IAuthenticationService
{
    AuthenticationCommandResult Login(LoginCommand command, CancellationToken cancellationToken);
    GenericCommandResult AccountVerification(AccountVerificationCommand command, CancellationToken cancellationToken);
    GenericCommandResult ChangePassword(ChangePasswordCommand command, CancellationToken cancellationToken);
}
