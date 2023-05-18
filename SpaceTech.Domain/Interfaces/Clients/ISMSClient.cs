using SpaceTech.Domain.Commands;

namespace SpaceTech.Domain.Interfaces.Clients;
public interface ISMSClient
{
    GenericCommandResult SendVerificationCode(string phoneNumber, string verificationCode);

}
