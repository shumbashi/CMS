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

			// تخصيص الحقول الخاصة بالوثيقة
			builder.Property(d => d.Code)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل Code إلى 50

			builder.Property(d => d.IssueDate)
				.IsRequired();  // تاريخ الإصدار مطلوب

			builder.Property(d => d.DocumentStatus)
				.IsRequired()
				.HasMaxLength(50);  // تحديد طول الحقل DocumentStatus إلى 50

			builder.Property(d => d.Notes)
				.HasMaxLength(255);  // تحديد طول الحقل Notes إلى 255

			builder.Property(d => d.AuthenticationNumber)
				.IsRequired();  // رقم التصديق مطلوب

			builder.Property(d => d.Clause)
				.HasMaxLength(500);  // تحديد طول الحقل Clause إلى 500

			// إضافة فهرسة للأعمدة

			builder.HasIndex(d => d.Code)
	.HasDatabaseName("UQ_DocumentCode")
	.IsUnique(true);

			builder.HasIndex(d => d.AuthenticationNumber)
				.HasDatabaseName("UQ_AuthenticationNumber")
				.IsUnique(true);

			// هذه مش فريدة
			builder.HasIndex(d => d.DocumentStatus)
				.HasDatabaseName("Idx_DocumentStatus")
				.IsUnique(false);

			builder.HasIndex(d => d.IssueDate)
				.HasDatabaseName("Idx_IssueDate")
				.IsUnique(false);
			
			// تحديد العلاقات مع جداول أخرى
			builder.HasOne(d => d.Template)
				.WithMany(t => t.Documents)
				.HasForeignKey(d => d.TemplateId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(d => d.Editor)
				.WithMany(e => e.Documents)
				.HasForeignKey(d => d.EditorId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(d => d.ContractPartyInDocuments)
				.WithOne(cpd => cpd.Document)
				.HasForeignKey(cpd => cpd.DocumentId);

			builder.HasMany(d => d.Attachments)
				.WithOne()
				.HasForeignKey(a => a.DocumentId);
		}
	}

}
