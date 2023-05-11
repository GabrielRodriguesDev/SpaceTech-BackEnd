namespace SpaceTech.Domain.Notifications;
public abstract class Notificable
{
    public Notificable()
    {
        Notifications = new List<Notification>();
    }

    public List<Notification> Notifications { get; private set; } = null!;

    public void AddNotification(string key, string value)
    {
        this.Notifications.Add(new Notification(key, value));
    }

    public void ClearNotifications()
    {
        this.Notifications.Clear();
    }

    public bool IsValid
    {
        get { return this.Notifications.Count() == 0; }
    }
    public bool Invalid
    {
        get { return this.Notifications.Count() > 0; }
    }

    public abstract void Validate();
}
