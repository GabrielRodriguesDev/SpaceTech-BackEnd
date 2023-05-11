using SpaceTech.Domain.Interfaces.Infrastructure;

namespace SpaceTech.WebAPI.Helpers;

public class ErrorCatalogHelper
{
    public static void SettingCatalogedError(HttpContext context, string error)
    {
        var errorManager = context.RequestServices.GetService<IErrorManager>()!;
        errorManager.SetCatalogedError(error);
    }
}
