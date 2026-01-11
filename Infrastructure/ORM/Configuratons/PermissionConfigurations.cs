using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class PermissionConfigurations : IEntityTypeConfiguration<Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder)
		{
			builder.HasKey(p => p.Id);  // المفتاح الأساسي

			builder.Property(p => p.Name)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل Name إلى 50

			builder.Property(p => p.Description)
				.HasMaxLength(255);  // تحديد طول الحقل Description إلى 255
		}
	}

}
