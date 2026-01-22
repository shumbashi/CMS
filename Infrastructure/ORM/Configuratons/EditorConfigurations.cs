using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class EditorConfigurations : IEntityTypeConfiguration<Editor>
	{
		public void Configure(EntityTypeBuilder<Editor> builder)
		{
			builder.HasKey(e => e.Id);  // المفتاح الأساسي

			builder.Property(e => e.InspectionNumber)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(e => e.SealNumber)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(e => e.DecisionNumber)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(e => e.CourtDivision)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(e => e.FinancialBalance)
				.IsRequired()
				.HasColumnType("decimal(15,2)");

			// العلاقة مع الهوية (Identity)
			builder.HasOne(e => e.Identity)
				.WithMany(i => i.Editors)
				.HasForeignKey(e => e.IdentityId)
				.IsRequired();  // العلاقة مع الهوية

			// إضافة فهرسة للأعمدة التي سيتم الفلترة عليها بشكل متكرر
			builder.HasIndex(e => e.InspectionNumber)
	.HasDatabaseName("UQ_InspectionNumber")
	.IsUnique(true);

			builder.HasIndex(e => e.SealNumber)
				.HasDatabaseName("UQ_SealNumber")
				.IsUnique(true);

			builder.HasIndex(e => e.DecisionNumber)
				.HasDatabaseName("UQ_DecisionNumber")
				.IsUnique(true);

			// هذه مش رقم رسمي فخليها غير فريدة
			builder.HasIndex(e => e.CourtDivision)
				.HasDatabaseName("Idx_CourtDivision")
				.IsUnique(false);

			builder.HasIndex(e => e.FinancialBalance)
				.HasDatabaseName("Idx_FinancialBalance")
				.IsUnique(false);

		}
	}
}
