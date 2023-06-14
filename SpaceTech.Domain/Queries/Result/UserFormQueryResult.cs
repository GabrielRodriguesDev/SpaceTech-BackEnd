namespace SpaceTech.Domain.Queries.Result;
public class UserFormQueryResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;

    public string Telephone { get; set; } = null!;
}
