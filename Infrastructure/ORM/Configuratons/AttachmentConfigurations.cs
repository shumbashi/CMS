using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class AttachmentConfigurations : IEntityTypeConfiguration<Attachment>
	{
		public void Configure(EntityTypeBuilder<Attachment> builder)
		{
			builder.HasKey(a => a.Id);  // المفتاح الأساسي

			builder.Property(a => a.AttachmentType)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(a => a.UploadDate)
				.IsRequired();

			builder.Property(a => a.StoragePath)
				.HasMaxLength(255);

			builder.Property(a => a.FileSize)
				.IsRequired();
		}
	}
}
