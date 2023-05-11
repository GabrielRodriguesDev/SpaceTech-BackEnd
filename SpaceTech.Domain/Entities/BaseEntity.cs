namespace SpaceTech.Domain.Entities;
public class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public DateTime? ChangedAt { get; private set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }

    public void setChangedAt()
    {
        ChangedAt = DateTime.Now;
    }
}
