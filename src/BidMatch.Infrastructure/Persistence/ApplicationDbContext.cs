using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BidMatch.Domain.Users.Entities;
using Microsoft.AspNetCore.Identity;
using OpenIddict.EntityFrameworkCore.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options), IApplicationDbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Auto apply configurations from IEntityTypeConfiguration<T>
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //// OpenIddict configurations
        //builder.UseOpenIddict();
    }
}