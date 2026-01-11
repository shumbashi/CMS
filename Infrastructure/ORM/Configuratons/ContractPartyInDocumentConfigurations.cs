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

			builder.Property(c => c.ContractPartyName)
				.IsRequired()
				.HasMaxLength(100);  // تحديد طول الحقل ContractPartyName إلى 100

			
			builder.Property(c => c.PartyRoleId)
				.IsRequired();  // تأكد من أن PartyRoleId مطلوب

			// إضافة العلاقات مع جداول الأطراف (ContractParty و Document)
			builder.HasOne(cpd => cpd.ContractParty)
				.WithMany(cp => cp.ContractPartyInDocuments)
				.HasForeignKey(cpd => cpd.ContractPartyId);  // المفتاح الخارجي ContractPartyId

			builder.HasOne(cpd => cpd.Document)
				.WithMany(d => d.ContractPartyInDocuments)
				.HasForeignKey(cpd => cpd.DocumentId);  // المفتاح الخارجي DocumentId

			builder.HasOne(cpd => cpd.PartyRole)
				.WithMany()  // لا حاجة لعلاقة عكسية في هذا السياق
				.HasForeignKey(cpd => cpd.PartyRoleId);  // المفتاح الخارجي PartyRoleId
		}
	}


}
