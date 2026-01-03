using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class DocumentConfigurations : IEntityTypeConfiguration<Document>
	{
		public void Configure(EntityTypeBuilder<Document> builder)
		{
			builder.HasKey(d => d.Id);  // المفتاح الأساسي

			builder.Property(d => d.CreationDate)
				.IsRequired();

			builder.Property(d => d.IssueDate)
				.IsRequired();

			builder.Property(d => d.DocumentStatus)
				.HasMaxLength(50);

			builder.Property(d => d.AuthenticationNumber)
				.IsRequired();

			builder.Property(d => d.CertificationLocation)
				.HasMaxLength(255);
		}
	}
}
