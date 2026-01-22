using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class PersonsInCompanyConfigurations : IEntityTypeConfiguration<PersonsInCompany>
	{
		public void Configure(EntityTypeBuilder<PersonsInCompany> builder)
		{
			builder.HasKey(p => p.Id);  // المفتاح الأساسي للجدول الوسيط

			builder.HasOne(p => p.Company)
				.WithMany(c => c.PersonsInCompany)
				.HasForeignKey(p => p.CompanyId);  // المفتاح الخارجي CompanyId

			builder.HasOne(p => p.ContractParty)
				.WithMany(cp => cp.PersonsInCompany)
				.HasForeignKey(p => p.ContractPartyId);  // المفتاح الخارجي ContractPartyId
														 // إضافة العلاقة مع Identity
			builder.HasOne(p => p.Identity)
				.WithMany(i => i.PersonsInCompanies)  // العلاقة العكسية مع Identity
				.HasForeignKey(p => p.IdentityId)
				.IsRequired();  // علاقة مع Identity

		}

	}
}
