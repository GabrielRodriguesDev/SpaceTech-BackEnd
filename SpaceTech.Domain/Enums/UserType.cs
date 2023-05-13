using System.ComponentModel;

namespace SpaceTech.Domain.Enums;
public enum UserType
{
    [Description("User type not defined")]
    Undefined = 0,
    [Description("Admin user")]
    Administrator = 1,
    [Description("Common user")]
    Common = 2,
}
