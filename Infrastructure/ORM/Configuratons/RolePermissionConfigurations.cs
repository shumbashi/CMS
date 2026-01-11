using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class RolePermissionConfigurations : IEntityTypeConfiguration<RolePermission>
	{
		public void Configure(EntityTypeBuilder<RolePermission> builder)
		{
			builder.HasKey(rp => rp.Id);  // المفتاح الأساسي

			// العلاقة مع Role
			builder.HasOne(rp => rp.Role)
				.WithMany(r => r.RolePermissions)
				.HasForeignKey(rp => rp.RoleId);  // المفتاح الخارجي RoleId

			// العلاقة مع Permission
			builder.HasOne(rp => rp.Permission)
				.WithMany()
				.HasForeignKey(rp => rp.PermissionId);  // المفتاح الخارجي PermissionId
		}
	}

}
