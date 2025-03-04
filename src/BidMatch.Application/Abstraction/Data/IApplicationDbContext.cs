using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using BidMatch.Domain.Users.Entities;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<UserRole> UserRoles { get; }
    DbSet<Permission> Permissions { get; }
    DbSet<RolePermission> RolePermissions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}