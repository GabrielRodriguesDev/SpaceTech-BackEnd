namespace SpaceTech.Infrastructure.Errors;
public class ErrorCatalog
{
    public static string NotSpecified = "(FE0001)";

    #region User
    public static string CreateUser = "(FE0002)";
    public static string UpdateUser = "(FE0003)";
    public static string GetUser = "(FE0004)";
    #endregion

    #region Authentication
    public static string Login = "(FE0005)";
    #endregion
}