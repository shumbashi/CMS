using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class DocumentFieldDataConfigurations : IEntityTypeConfiguration<DocumentFieldData>
	{
		public void Configure(EntityTypeBuilder<DocumentFieldData> builder)
		{
			builder.HasKey(d => d.Id);  // المفتاح الأساسي

			builder.Property(d => d.FieldName)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(d => d.FieldValue)
				.IsRequired();

			
		}
	}
	}
