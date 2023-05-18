using SpaceTech.Domain.Helpers;
using SpaceTech.Domain.Notifications;

namespace SpaceTech.Domain.Commands.Authentication;
public class AccountVerificationCommand : Notificable
{
    public string? Email { get; set; }

    public override void Validate()
    {
        if (!InformationValidationHelper.EmailIsValid(Email!))
            this.AddNotification("Email", "Please provide valid email.");
    }
}
