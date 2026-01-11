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
			// تعيين المفتاح الأساسي
			builder.HasKey(d => d.Id);  // استخدام `Id` من `BaseEntity` كـ Primary Key

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

			// تحديد العلاقات مع جداول أخرى
			builder.HasOne(d => d.Template)
				.WithMany(t => t.Documents)
				.HasForeignKey(d => d.TemplateId)  // المفتاح الخارجي TemplateId
				.OnDelete(DeleteBehavior.Cascade);  // عند حذف القالب، يتم حذف الوثائق المرتبطة

			builder.HasOne(d => d.Editor)
				.WithMany(e => e.Documents)
				.HasForeignKey(d => d.EditorId)  // المفتاح الخارجي EditorId
				.OnDelete(DeleteBehavior.Restrict);  // لا يمكن حذف المحرر إذا كانت هناك وثائق مرتبطة

			// العلاقة مع الأطراف عبر جدول ContractPartyInDocument (متعدد إلى متعدد)
			builder.HasMany(d => d.ContractPartyInDocuments)
				.WithOne(cpd => cpd.Document)
				.HasForeignKey(cpd => cpd.DocumentId);  // المفتاح الخارجي DocumentId

			// العلاقة مع المرفقات
			builder.HasMany(d => d.Attachments)
				.WithOne()
				.HasForeignKey(a => a.DocumentId);  // المفتاح الخارجي DocumentId للمرفقات
		}
	}

}
