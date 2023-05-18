using SpaceTech.Domain.Commands;
using SpaceTech.Domain.Interfaces.Clients;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SpaceTech.CrossCutting.Clients;
public class SMSClient : ISMSClient
{
    public GenericCommandResult SendVerificationCode(string phoneNumber, string verificationCode)
    {
        string accountSid = "ACfd0d7a94006773db29a04af543bb21f9";
        string authToken = "bf4b659311cac9d05eeab1316c79b815";
        string twilioPhoneNumber = "+12526595377";

        try
        {
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
            body: $"Seu código de verificação: {verificationCode}",
            from: new Twilio.Types.PhoneNumber(twilioPhoneNumber),
            to: new Twilio.Types.PhoneNumber("+55" + phoneNumber)
             );


            if (message.Status == MessageResource.StatusEnum.Queued || message.Status == MessageResource.StatusEnum.Sent)
            {
                return new GenericCommandResult(true, "Verification code sent successfully.");
            }
            else
            {
                return new GenericCommandResult(false, $"Sorry, we were unable to send you the verification code, please try again later. Status: {message.Status}");
            }
        }
        catch (Exception)
        {
            return new GenericCommandResult(false, $"Sorry, we encountered a problem trying to send the SMS contact the admin");
        }
    }
}
