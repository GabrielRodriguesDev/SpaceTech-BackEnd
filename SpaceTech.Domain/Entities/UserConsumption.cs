namespace SpaceTech.Domain.Entities;
public class UserConsumption : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public string Url { get; set; } = null!;
}
