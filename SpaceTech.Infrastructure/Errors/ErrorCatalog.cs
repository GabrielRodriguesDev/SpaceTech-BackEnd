namespace SpaceTech.Infrastructure.Errors;
public class ErrorCatalog
{
    public static string NotSpecified = "(SE0001)";

    #region User
    public static string CreateUser = "(SE0002)";
    public static string UpdateUser = "(SE0003)";
    public static string GetUser = "(SE0004)";
    public static string DeleteUser = "(SE0005)";
    #endregion

    #region Authentication
    public static string Login = "(SE0005)";
    #endregion
}