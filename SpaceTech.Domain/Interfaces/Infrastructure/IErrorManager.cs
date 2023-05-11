namespace SpaceTech.Domain.Interfaces.Infrastructure;
public interface IErrorManager
{
    void SetCatalogedError(string errorCatalog);
    string GetCatalogedError();
}
