using SpaceTech.Domain.Commands.Authentication;
using SpaceTech.Domain.Interfaces.Repository;
using SpaceTech.Domain.Interfaces.Services;
using SpaceTech.Domain.Models;

namespace SpaceTech.Domain.Services;
public class AuthenticationService : IAuthenticationService
{
    private IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public AuthenticationCommandResult Login(LoginCommand command, CancellationToken cancellationToken)
    {
        command.Validate();
        if (command.Invalid) return new AuthenticationCommandResult(false, "Ops! Something went wrong.", command.Notifications);

        var userDb = _userRepository.GetUserByEmail(command.Email!);

        if (userDb is null)
            return new AuthenticationCommandResult(false, "Username or password is invalid.");

        if (!BCrypt.Net.BCrypt.Verify(command.Password, userDb.Password))
            return new AuthenticationCommandResult(false, "Username or password is invalid.");

        return new AuthenticationCommandResult(true, "User authenticated successfully", null, new AuthenticatedModel
        {
            Id = userDb.Id.ToString(),
            Name = userDb.Name,
            Email = userDb.Email
        });
    }
}
