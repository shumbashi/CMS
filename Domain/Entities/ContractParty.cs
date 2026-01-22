using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class ContractParty : BaseEntity, IAggregateRoot
	{
		public string ContractPartyName { get; set; }  // اسم الشخص في الطرف
		public string Residence { get; set; }  // محل الإقامة (NOT NULL)

		// علاقة متعدد إلى متعدد مع الوثائق عبر جدول ContractPartyInDocument
		public ICollection<ContractPartyInDocument> ContractPartyInDocuments { get; set; }  // علاقة مع الوثائق عبر جدول مساعد
																							// العلاقة مع الهوية (Identity)
		public Guid IdentityId { get; set; }  // مفتاح خارجي لربط الطرف بالهوية
		public Identity Identity { get; set; }  // العلاقة مع الهوية
												
		public ICollection<PersonsInCompany> PersonsInCompany { get; set; }  // العلاقة مع الأشخاص في الشركة


	}
}
