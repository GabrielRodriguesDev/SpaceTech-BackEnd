namespace SpaceTech.WebAPI.Helpers;

public class CookieHelper
{
    public static void SetCookie (HttpResponse respose, string token)
    {
        respose.Cookies.Append("X-Access-Token", token, new CookieOptions() { MaxAge = TimeSpan.FromDays(1) });
    }

    public static void ClearCookie (HttpResponse respose)
    {
        respose.Cookies.Append("X-Access-Token", "false", new CookieOptions() { Expires = DateTime.Now.AddDays(-1D) });
    }
}
