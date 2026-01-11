using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class CompanyConfigurations : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.HasKey(c => c.Id);  // المفتاح الأساسي

			builder.Property(c => c.CompanyName)
				.IsRequired()
				.HasMaxLength(100);  // تحديد طول الحقل CompanyName إلى 100

			builder.Property(c => c.CommercialRecord)
				.HasMaxLength(50);  // تحديد طول الحقل CommercialRecord إذا كان موجودًا

			// العلاقة مع جدول PersonsInCompany (متعدد إلى متعدد)
			builder.HasMany(c => c.PersonsInCompany)
				.WithOne(p => p.Company)
				.HasForeignKey(p => p.CompanyId);  // المفتاح الخارجي CompanyId في الجدول الوسيط

		}
	}

}
