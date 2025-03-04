using BidMatch.Domain.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BidMatch.Infrastructure.Persistence.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .HasIndex(u => u.UserName)
            .IsUnique();

        builder.Property(u => u.FirstName)
            .HasMaxLength(256);

        builder.Property(u => u.LastName)
            .HasMaxLength(256);

        builder.HasMany(rp => rp.UserRoles)
            .WithOne(r => r.User)
            .HasForeignKey(rp => rp.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}