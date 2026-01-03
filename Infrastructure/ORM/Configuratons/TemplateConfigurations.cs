using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class TemplateConfigurations : IEntityTypeConfiguration<Template>
	{
		public void Configure(EntityTypeBuilder<Template> builder)
		{
			builder.HasKey(t => t.Id);  // المفتاح الأساسي

			builder.Property(t => t.TemplateName)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(t => t.TemplateStatus)
				.HasMaxLength(50);
		}
	}
}
