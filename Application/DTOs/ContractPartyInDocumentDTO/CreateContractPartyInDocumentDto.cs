using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ContractPartyInDocumentDTO
{
    public class CreateContractPartyInDocumentDto
    {
		
		public Guid DocumentId { get; set; }  // معرف الوثيقة (Foreign Key)

		public string ContractPartyRole { get; set; }  // دور الطرف (طرف في الوثيقة)
	}
}
