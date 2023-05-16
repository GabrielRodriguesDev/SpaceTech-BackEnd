﻿using SpaceTech.Domain.Attributes;

namespace SpaceTech.Domain.Queries.Result;
public class UserListResult
{
    [Search]
    public string Name { get; set; } = null!;
    [Search]
    public string Surname { get; set; } = null!;
    [Search]
    public string Email { get; set; } = null!;
}