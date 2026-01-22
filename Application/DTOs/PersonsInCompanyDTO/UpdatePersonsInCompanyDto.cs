using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.PersonsInCompanyDTO
{
    public class UpdatePersonsInCompanyDto
    {
		public Guid Id { get; set; }  // معرف الشخص في الشركة
		public string PersonName { get; set; }  // اسم الشخص
		public Guid CompanyId { get; set; }  // معرف الشركة
		public Guid ContractPartyId { get; set; }  // معرف الطرف
		public Guid PartyRoleId { get; set; }  // معرف دور الطرف
		public Guid IdentityId { get; set; }  // معرف الهوية

	}
}
