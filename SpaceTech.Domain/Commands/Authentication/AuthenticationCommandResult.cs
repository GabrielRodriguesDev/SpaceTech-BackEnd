using SpaceTech.Domain.Models;

namespace SpaceTech.Domain.Commands.Authentication;
public class AuthenticationCommandResult
{
    public AuthenticationCommandResult(bool sucess, string message)
    {
        Sucess = sucess;
        Message = message;
    }

    public AuthenticationCommandResult(bool sucess, string message, Object? data, AuthenticatedModel? authenticated = null)
    {
        Sucess = sucess;
        Message = message;
        Authenticated = authenticated;
        Data = data;
    }

    public bool Sucess { get; set; }
    public string Message { get; set; } = null!;
    public object? Data { get; set; }
    public AuthenticatedModel? Authenticated { get; set; }
}
