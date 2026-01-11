using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class PersonsInCompany : BaseEntity, IAggregateRoot
	{

		public Guid CompanyId { get; set; }  // المفتاح الخارجي لجدول Company
		public Company Company { get; set; }  // العلاقة مع جدول Company

		public Guid ContractPartyId { get; set; }  // المفتاح الخارجي لجدول ContractParty
		public ContractParty ContractParty { get; set; }  // العلاقة مع جدول ContractParty

		public Guid PartyRoleId { get; set; }  // معرف دور الطرف (Foreign Key)
		public PartyRole PartyRole { get; set; }  // العلاقة مع دور الطرف
	}

}
