﻿using SpaceTech.Domain.Commands;
using SpaceTech.Domain.Commands.User;
using SpaceTech.Domain.Entities;
using SpaceTech.Domain.Interfaces;
using SpaceTech.Domain.Interfaces.Repository;
using SpaceTech.Domain.Interfaces.Services;

namespace SpaceTech.Domain.Services;
public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private IUnitOfWork _uow;

    public UserService(
        IUserRepository userRepository,
        IUnitOfWork uow
        )
    {
        _userRepository = userRepository;
        _uow = uow;
    }

    public GenericCommandResult Create(CreateUserCommand command, CancellationToken cancellationToken)
    {
        command.Validate();
        if (command.Invalid) return new GenericCommandResult(false, "Ops! Something went wrong.", command.Notifications);

        var existsByEmail = _userRepository.ThereIsUserByEmail(command.Email);
        if (existsByEmail) return new GenericCommandResult(false, "Please, This is already a record associated with this email.");

        User user = new User(command);

        _uow.BeginTransaction();

        try
        {
            _userRepository.Create(user);
            _uow.Commit();
        }
        catch (Exception)
        {
            _uow.Rollback();
            throw;
        }

        return new GenericCommandResult(true, "User created successfully.", new UserCommandResult()
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email
        });
    }    
}