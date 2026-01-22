using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ContractPartyDTO
{
    public class CreateContractPartyDto
    {
		public string ContractPartyName { get; set; }  // اسم الشخص في الطرف
		public string Residence { get; set; }  // محل الإقامة (NOT NULL)

		public ICollection<Guid> DocumentIds { get; set; }  // معرفات الوثائق (بدلاً من تضمين الكائنات)
		public ICollection<Guid> CompanyIds { get; set; }  // معرفات الشركات (بدلاً من تضمين الكائنات)

	}
}
