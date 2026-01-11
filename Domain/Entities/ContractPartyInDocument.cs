using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class ContractPartyInDocument : BaseEntity, IAggregateRoot
	{
		public string ContractPartyName { get; set; }  // اسم الطرف في الوثيقة

		public Guid DocumentId { get; set; }  // معرف الوثيقة (Foreign Key)
		public Document Document { get; set; }  // العلاقة مع الوثيقة

		public Guid ContractPartyId { get; set; }  // معرف الطرف (Foreign Key)
		public ContractParty ContractParty { get; set; }  // العلاقة مع الطرف

		public Guid PartyRoleId { get; set; }  // معرف دور الطرف (Foreign Key)
		public PartyRole PartyRole { get; set; }  // العلاقة مع دور الطرف
	}
	
		
	
}
