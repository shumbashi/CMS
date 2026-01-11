using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class RoleConfigurations : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasKey(r => r.Id);  // المفتاح الأساسي

			builder.Property(r => r.Name)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل Name إلى 50

			builder.Property(r => r.Description)
				.HasMaxLength(255);  // تحديد طول الحقل Description إلى 255

			// العلاقة مع RolePermissions (متعدد إلى متعدد مع Permission)
			builder.HasMany(r => r.RolePermissions)
				.WithOne(rp => rp.Role)
				.HasForeignKey(rp => rp.RoleId);  // المفتاح الخارجي RoleId

			// العلاقة مع UserRoles (متعدد إلى واحد مع User)
			builder.HasMany(r => r.UserRoles)
				.WithOne(ur => ur.Role)
				.HasForeignKey(ur => ur.RoleId);  // المفتاح الخارجي RoleId
		}
	}

}
