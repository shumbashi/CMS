using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class ContractPartyConfigurations : IEntityTypeConfiguration<ContractParty>
	{
		public void Configure(EntityTypeBuilder<ContractParty> builder)
		{
			builder.HasKey(c => c.Id);  // المفتاح الأساسي

			builder.Property(c => c.ContractPartyType)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(c => c.ContractPartyName)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(c => c.Representative)
				.HasMaxLength(50);

			builder.Property(c => c.Nationality)
				.HasMaxLength(50);

			builder.Property(c => c.PhoneNumber)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(c => c.Residence)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(c => c.BirthDate)
				.IsRequired();

			builder.Property(c => c.NationalId)
				.HasMaxLength(50);

			builder.Property(c => c.IdentityProof)
				.HasMaxLength(50);
		}
	}
}
