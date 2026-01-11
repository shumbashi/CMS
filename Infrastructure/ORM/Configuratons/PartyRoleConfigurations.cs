using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class PartyRoleConfigurations : IEntityTypeConfiguration<PartyRole>
	{
		public void Configure(EntityTypeBuilder<PartyRole> builder)
		{
			builder.HasKey(pr => pr.Id);  // المفتاح الأساسي

			builder.Property(pr => pr.RoleName)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل RoleName إلى 50

			builder.Property(pr => pr.RoleCode)
				.HasMaxLength(50);  // تحديد طول الحقل RoleCode إذا كان موجودًا
		}
	}
}
