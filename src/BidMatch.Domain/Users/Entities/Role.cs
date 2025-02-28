using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

namespace BidMatch.Domain.Users.Entities;

public sealed class Role : IdentityRole<Guid>
{
    public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
    public ICollection<RolePermission> RolePermissions { get; private set; } = new List<RolePermission>();

    private Role() { }

    public Role(string name)
    {
        Id = Guid.CreateVersion7();
        Name = name;
    }
}
