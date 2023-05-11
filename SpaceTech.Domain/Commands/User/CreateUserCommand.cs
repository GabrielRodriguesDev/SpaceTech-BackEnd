using SpaceTech.Domain.Helpers;
using SpaceTech.Domain.Notifications;

namespace SpaceTech.Domain.Commands.User;
public class CreateUserCommand : Notificable
{
    public string? Name { get; set; } = null!;
    public string? Surname { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string Email { get; set; } = null!;

    public override void Validate()
    {
        if (String.IsNullOrEmpty(Name))
        {
            this.AddNotification("Name", "inform the name.");
        }
        else
        {
            if (Name.Length > 120)
            {
                this.AddNotification("Name", "The name can only contain up to 120 characters.");
            }
        }

        if (String.IsNullOrEmpty(Surname))
        {
            this.AddNotification("Surname", "inform the surname.");
        }
        else
        {
            if (Surname.Length > 220)
            {
                this.AddNotification("Surname", "The surname can only contain up to 220 characters.");
            }
        }

        if (!InformationValidationHelper.EmailIsValid(Email))
        {
            this.AddNotification("Email", "Please provide valid email.");
        }
        else
        {
            if (Email.Length > 120)
            {
                this.AddNotification("Email", "The email can only contain up to 220 characters.");
            }
        }

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

    }
}