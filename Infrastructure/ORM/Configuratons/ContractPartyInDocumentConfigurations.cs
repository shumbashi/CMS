using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ORM.Configuratons
{
	public class ContractPartyInDocumentConfigurations : IEntityTypeConfiguration<ContractPartyInDocument>
	{
		public void Configure(EntityTypeBuilder<ContractPartyInDocument> builder)
		{
			builder.HasKey(c => c.Id);  // المفتاح الأساسي

			builder.Property(c => c.ContractPartyRole)
				.IsRequired()
				.HasMaxLength(50);
		}
	}
}
