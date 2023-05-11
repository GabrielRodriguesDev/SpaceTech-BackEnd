using SpaceTech.Domain.Interfaces.Infrastructure;

namespace SpaceTech.Infrastructure.Errors;
public class ErrorManager : IErrorManager
{
    public string Error { get; set; } = ErrorCatalog.NotSpecified;
    public string GetCatalogedError()
    {
        return Error;
    }

    public void SetCatalogedError(string errorCatalog)
    {
        Error = errorCatalog;
    }
}