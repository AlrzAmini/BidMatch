using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using BidMatch.Domain.Users.Entities;

public sealed class User : IdentityUser<Guid>
{
    public string IdentityId { get; private set; } = default!;
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();

    public User() : base()
    {
        Id = Guid.CreateVersion7();
    }

    private User(string username)
    {
        Id = Guid.CreateVersion7();
        UserName = username;
    }

    public static User Create(string username)
    {
        return new User(username);
    }

    public void SetIdentityId(string identityId)
    {
        IdentityId = identityId;
    }
}