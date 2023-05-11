using System.Text.RegularExpressions;

namespace SpaceTech.Domain.Helpers;
public class InformationValidationHelper
{
    public static bool EmailIsValid(string email)
    {
        if (email is null) return false;

        Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
        RegexOptions.CultureInvariant | RegexOptions.Singleline);

        return regex.IsMatch(email);
    }

    public static string? PasswordIsValid(string password)
    {
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasLowerChar = new Regex(@"[a-z]+");
        var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
        string result = "";

        if (password.Length < 8 || password.Length > 16)
        {
            result = result.TrimStart() + " Password must contain a minimum of 8 characters and a maximum of 16.";
        }

        if (!hasLowerChar.IsMatch(password))
        {
            result = result.TrimStart() + "@Password should contain at least one lower case letter.";
        }

        if (!hasUpperChar.IsMatch(password))
        {
            result = result.TrimStart() + "@Password should contain at least one upper case letter.";
        }

        if (!hasNumber.IsMatch(password))
        {
            result = result.TrimStart() + "@Password should contain at least one numeric value.";
        }

        if (!hasSymbols.IsMatch(password))
        {
            result = result.TrimStart() + "@Password should contain at least one special case characters.";
        }


        return result;
    }


}
