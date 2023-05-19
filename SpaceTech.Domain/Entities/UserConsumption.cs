using SpaceTech.Domain.Commands.UserConsumption;

namespace SpaceTech.Domain.Entities;
public class UserConsumption : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string ConsumedAPI { get; set; } = null!;

    public UserConsumption(CreateUserConsumptionCommand command)
    {
        UserId = command.UserId!.Value;
        Url = command.Url!;
        ConsumedAPI = command.ConsumedAPI!;
    }

    public UserConsumption() { }

}
