using SpaceTech.Domain.Helpers;
using SpaceTech.Domain.Notifications;

namespace SpaceTech.Domain.Commands.User;
public class UpdateUserCommand : Notificable
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = null!;
    public string? Surname { get; set; }
    public string Email { get; set; } = null!;

    public override void Validate()
    {
        if(Id is null)
        {
            this.AddNotification("Id", "Inform the Id.");
        }
        if (String.IsNullOrEmpty(Name))
        {
            this.AddNotification("Name", "Inform the name.");
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

    }
}
