using SpaceTech.Domain.Commands.User;

namespace SpaceTech.Domain.Entities;
public class User : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Surname { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;


    public User() : base() { }
    public User(CreateUserCommand command)
    {
        Name = command.Name!;
        Surname = command.Surname!;
        Email = command.Email;
        Password = BCrypt.Net.BCrypt.HashPassword(command.Password);
    }

    public void Update(UpdateUserCommand command)
    {
        Name = command.Name!;
        Surname = command.Surname!;
        Email = command.Email;
    }
}
