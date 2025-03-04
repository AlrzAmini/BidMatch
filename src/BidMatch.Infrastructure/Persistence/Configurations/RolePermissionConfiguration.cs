using BidMatch.Domain.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidMatch.Infrastructure.Persistence.Configurations
{

    internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermissions");

            builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder
                .HasIndex(rp => new { rp.RoleId, rp.PermissionId })
                .IsUnique();


            builder.HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId)
                .IsRequired();

            builder.HasOne(rp => rp.Permission)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId)
                .IsRequired();
        }
    }
}
