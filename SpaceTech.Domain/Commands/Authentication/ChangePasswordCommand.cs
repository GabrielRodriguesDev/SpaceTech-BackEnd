using SpaceTech.Domain.Helpers;
using SpaceTech.Domain.Notifications;

namespace SpaceTech.Domain.Commands.Authentication;
public class ChangePasswordCommand : Notificable
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string? VerificationCode { get; set; }

    public override void Validate()
    {
        if (!InformationValidationHelper.EmailIsValid(Email!))
            this.AddNotification("Email", "Please provide valid email.");

        if (String.IsNullOrWhiteSpace(Password))
        {
            this.AddNotification("Password", "Enter your Password.");
        }
        else
        {
            var resultPassword = InformationValidationHelper.PasswordIsValid(Password);
            if (!String.IsNullOrEmpty(resultPassword))
            {
                this.AddNotification("Password", resultPassword.Replace("@", " " + Environment.NewLine + " "));
            }
        }

        if (String.IsNullOrWhiteSpace(ConfirmPassword))
        {
            this.AddNotification("ConfirmPassword", "Enter your password confirmation.");
        }
        else
        {
            if (!Password!.Equals(ConfirmPassword))
            {
                this.AddNotification("ConfirmPassword", "Password confirmation does not match the password entered.");
            }
        }

        if (String.IsNullOrWhiteSpace(VerificationCode))
        {
            this.AddNotification("VerificationCode", "Enter your verification code.");
        }
        else
        {
            if (VerificationCode.Length > 5)
            {
                this.AddNotification("VerificationCode", "The verification code can only contain up to 5 characters.");
            }
        }
    }
}
