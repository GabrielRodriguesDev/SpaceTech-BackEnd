namespace SpaceTech.Domain.Queries;
public class UserQueries
{
    public static string ThereIsUserByEmail()
    {
        return @" SELECT COUNT(1) FROM User WHERE Email = @Email";
    }

    public static string GetUserByEmail()
    {
        return @" SELECT * FROM User WHERE Email = @Email;";
    }


}
