using SpaceTech.Domain.Commands.User;
using SpaceTech.Domain.Enums;

namespace SpaceTech.Domain.Entities;
public class User : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Surname { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public UserType UserType { get; private set; }
    public string Telephone { get; private set; } = null!;


    public User() : base() { }
    public User(CreateUserCommand command)
    {
        Name = command.Name!;
        Surname = command.Surname!;
        Email = command.Email;
        Password = BCrypt.Net.BCrypt.HashPassword(command.Password);
        UserType = UserType.Common;
        Telephone = command.Telephone;
    }

    public void Update(UpdateUserCommand command)
    {
        Name = command.Name!;
        Surname = command.Surname!;
        Email = command.Email;
        Telephone = command.Telephone;
    }
}
