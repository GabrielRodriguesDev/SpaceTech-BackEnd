using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTech.Domain.Notifications;
public class Notification
{
    public Notification(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;
}
