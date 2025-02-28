using Microsoft.AspNetCore.Identity;

namespace BidMatch.Domain.Users.Entities;

public sealed class User : IdentityUser<Guid>
{
    public string IdentityId { get; private set; }

    public string? FirstName { get; private set; }

    public string? LastName { get; private set; }

    public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();

    private User() { }

    private User(string username)
    {
        Id = Guid.CreateVersion7();
        UserName = username;
    }

    public static User Create(string username)
    {
        var user = new User(username);
        return user;
    }

    public void SetIdentityId(string identityId)
    {
        IdentityId = identityId;
    }
}

