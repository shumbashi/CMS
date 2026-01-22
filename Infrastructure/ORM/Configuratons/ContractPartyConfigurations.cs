using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ContractPartyConfigurations : IEntityTypeConfiguration<ContractParty>
{
	public void Configure(EntityTypeBuilder<ContractParty> builder)
	{
		builder.HasKey(c => c.Id);  // المفتاح الأساسي

		builder.Property(c => c.ContractPartyName)
			.IsRequired()
			.HasMaxLength(100);  // تحديد طول الحقل ContractPartyName إلى 100

		builder.Property(c => c.Residence)
			.IsRequired()
			.HasMaxLength(100);  // تحديد طول الحقل Residence إلى 100

		// العلاقة مع جدول ContractPartyInDocument (متعدد إلى متعدد)
		builder.HasMany(c => c.ContractPartyInDocuments)
			.WithOne(cpd => cpd.ContractParty)
			.HasForeignKey(cpd => cpd.ContractPartyId);  // المفتاح الخارجي ContractPartyId

		// العلاقة مع جدول PersonsInCompany (متعدد إلى متعدد عبر جدول وسيط)
		builder.HasMany(c => c.PersonsInCompany)
			.WithOne(p => p.ContractParty)
			.HasForeignKey(p => p.ContractPartyId);  // المفتاح الخارجي ContractPartyId في الجدول الوسيط

		// العلاقة مع Identity
		builder.HasOne(c => c.Identity)
			.WithMany(i => i.ContractParties)
			.HasForeignKey(c => c.IdentityId)
			.IsRequired();  // العلاقة مع Identity
	}
}
