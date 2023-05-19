namespace SpaceTech.Infrastructure.Errors;
public class ErrorCatalog
{
    public static string NotSpecified = "(SE0001)";

    #region User
    public static string CreateUser = "(SE0002)";
    public static string UpdateUser = "(SE0003)";
    public static string GetUser = "(SE0004)";
    public static string DeleteUser = "(SE0005)";
    public static string SearchUser = "(SE0006)";
    #endregion

    #region Authentication
    public static string Login = "(SE0007)";
    public static string Logout = "(SE0008)";
    public static string AccountVerification = "(SE0009)";
    public static string ChangePassword = "(SE0010)";
    #endregion

    #region UserConsumption
    public static string RegisteringConsumption = "(SE0011)";
    #endregion
}