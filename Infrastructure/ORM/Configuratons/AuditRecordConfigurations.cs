using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class AuditRecordConfigurations : IEntityTypeConfiguration<AuditRecord>
	{
		public void Configure(EntityTypeBuilder<AuditRecord> builder)
		{
			builder.HasKey(a => a.Id);  // المفتاح الأساسي

			builder.Property(a => a.ActionType)
				.HasMaxLength(50);

			builder.Property(a => a.ActionDate)
				.IsRequired();

			builder.Property(a => a.IpAddress)
				.HasMaxLength(50);

			builder.Property(a => a.AffectedEntityName)
				.HasMaxLength(50);

			builder.Property(a => a.AffectedEntityId);

			builder.Property(a => a.ChangeDetails)
				.HasMaxLength(255);
		}
	}
}
