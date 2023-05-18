using SpaceTech.Domain.Commands;
using SpaceTech.Domain.Commands.Authentication;
using SpaceTech.Domain.Entities;
using SpaceTech.Domain.Helpers;
using SpaceTech.Domain.Interfaces;
using SpaceTech.Domain.Interfaces.Clients;
using SpaceTech.Domain.Interfaces.Repository;
using SpaceTech.Domain.Interfaces.Services;
using SpaceTech.Domain.Models;

namespace SpaceTech.Domain.Services;
public class AuthenticationService : IAuthenticationService
{
    private IUserRepository _userRepository;
    private ISMSClient _SMSClient;
    private IUnitOfWork _uow;

    public AuthenticationService(
        IUserRepository userRepository,
        ISMSClient SMSClient,
        IUnitOfWork uow
        )
    {
        _userRepository = userRepository;
        _SMSClient = SMSClient;
        _uow = uow;
    }



    public AuthenticationCommandResult Login(LoginCommand command, CancellationToken cancellationToken)
    {
        command.Validate();
        if (command.Invalid) return new AuthenticationCommandResult(false, "Ops! Something went wrong.", command.Notifications);

        var user = _userRepository.GetUserByEmail(command.Email!);

        if (user is null)
            return new AuthenticationCommandResult(false, "Username or password is invalid.");

        if (!BCrypt.Net.BCrypt.Verify(command.Password, user.Password))
            return new AuthenticationCommandResult(false, "Username or password is invalid.");

        return new AuthenticationCommandResult(true, "User authenticated successfully", null, new AuthenticatedModel
        {
            Id = user.Id.ToString(),
            Name = user.Name,
            Email = user.Email,
            UserType = user.UserType
        });
    }

    public GenericCommandResult AccountVerification(AccountVerificationCommand command, CancellationToken cancellationToken)
    {
        command.Validate();
        if (command.Invalid) return new GenericCommandResult(false, "Ops! Something went wrong.", command.Notifications);

        var user = _userRepository.GetUserByEmail(command.Email!);

        if (user is null)
            return new GenericCommandResult(false, "User not found.");

        var verificationCode = InformationGeneratorHelper.GenerateVerificationCode();

        var result = _SMSClient.SendVerificationCode(user.Telephone, verificationCode);

        if(!result.Sucess)
        {
            return result;
        }

        user.setVerificationCode(verificationCode);

        _uow.BeginTransaction();

        try
        {
            _userRepository.Update(user);
            _uow.Commit();
        }
        catch (Exception)
        {
            _uow.Rollback();
            throw;
        }


        return new GenericCommandResult(true, "Verification code sent successfully, code validity expires in 7 minutes.");

    }

    public GenericCommandResult ChangePassword(ChangePasswordCommand command, CancellationToken cancellationToken)
    {
        command.Validate();
        if (command.Invalid) return new GenericCommandResult(false, "Ops! Something went wrong.", command.Notifications);

        var user = _userRepository.GetUserByEmail(command.Email!);

        if (user is null)
            return new GenericCommandResult(false, "User not found.");

        if(user.VerificationCode != command.VerificationCode)
        {
            return new GenericCommandResult(false, "Invalid verification code.");

        } else
        {
            if(DateTime.Now > user.VerificationCodeExpiration)
            {
                return new GenericCommandResult(false, "Verification code expired, generate a new code.");
            }
        }

        user.setPassword(command.Password!);
        _uow.BeginTransaction();

        try
        {
            _userRepository.Update(user);
            _uow.Commit();
        }
        catch (Exception)
        {
            _uow.Rollback();
            throw;
        }

        return new GenericCommandResult(true, "Password changed successfully.");
    }
}
