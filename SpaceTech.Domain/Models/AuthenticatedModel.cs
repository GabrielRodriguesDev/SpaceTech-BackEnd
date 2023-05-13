using SpaceTech.Domain.Enums;

namespace SpaceTech.Domain.Models;
public class AuthenticatedModel
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public UserType UserType { get; set; }
    public string? Token { get; set; }
}
