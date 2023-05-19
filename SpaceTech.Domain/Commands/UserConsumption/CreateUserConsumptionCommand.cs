using SpaceTech.Domain.Notifications;

namespace SpaceTech.Domain.Commands.UserConsumption;
public class CreateUserConsumptionCommand : Notificable
{
    public Guid? UserId { get; set; }
    public string? Url { get; set; }

    public override void Validate()
    {
        if(UserId is null)
        {
            this.AddNotification("UserId", "Enter the User Id");
        }

        if (String.IsNullOrEmpty(Url))
        {
            this.AddNotification("Url", "Enter the URL");
        } else
        {
            if(Url.Length > 500)
            {
                this.AddNotification("Url", "The url can only contain up to 500 characters.");
            }
        }
    }
}
