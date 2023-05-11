using SpaceTech.Domain.Helpers;
using SpaceTech.Domain.Notifications;

namespace SpaceTech.Domain.Commands.Authentication;
public class LoginCommand : Notificable
{
    public string? Email { get; set; }
    public string? Password { get; set; }

    public override void Validate()
    {
        if (!InformationValidationHelper.EmailIsValid(Email!))
            this.AddNotification("Email", "Please provide valid email.");

        if (String.IsNullOrEmpty(Password))
            this.AddNotification("Password", "Please provide password.");
    }
}
