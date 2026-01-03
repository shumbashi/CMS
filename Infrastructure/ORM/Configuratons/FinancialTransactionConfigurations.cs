using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class FinancialTransactionConfigurations : IEntityTypeConfiguration<FinancialTransaction>
	{
		public void Configure(EntityTypeBuilder<FinancialTransaction> builder)
		{
			builder.HasKey(f => f.Id);  // المفتاح الأساسي

			builder.Property(f => f.TransactionStatus)
				.HasMaxLength(50);

			builder.Property(f => f.TransactionType)
				.HasMaxLength(50);

			builder.Property(f => f.TransactionDate)
				.IsRequired();

			builder.Property(f => f.Amount)
				.HasColumnType("decimal(15,2)");
		}
	}
}
