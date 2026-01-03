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

			builder.Property(e => e.BirthDate)
				.IsRequired();

			builder.Property(e => e.FinancialBalance)
				.IsRequired()
				.HasColumnType("decimal(15,2)");

			builder.Property(e => e.Length)
				.IsRequired()
				.HasColumnType("decimal(15,2)");

			builder.Property(e => e.Width)
				.IsRequired()
				.HasColumnType("decimal(15,2)");
		}
	}
}
