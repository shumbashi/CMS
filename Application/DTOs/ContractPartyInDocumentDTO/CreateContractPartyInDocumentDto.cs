using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ContractPartyInDocumentDTO
{
    public class CreateContractPartyInDocumentDto
    {

		public string ContractPartyName { get; set; }  // اسم الطرف في الوثيقة
		public Guid DocumentId { get; set; }  // معرف الوثيقة
		public Guid ContractPartyId { get; set; }  // معرف الطرف
		public Guid PartyRoleId { get; set; }  // معرف دور الطرف
	}
}
