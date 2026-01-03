using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class TemplateFieldConfigurations : IEntityTypeConfiguration<TemplateField>
	{
		public void Configure(EntityTypeBuilder<TemplateField> builder)
		{
			builder.HasKey(t => t.Id);  // المفتاح الأساسي

			builder.Property(t => t.FieldName)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(t => t.ExpectedDataType)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(t => t.FieldDescription)
				.HasMaxLength(255);
		}
	}
}
