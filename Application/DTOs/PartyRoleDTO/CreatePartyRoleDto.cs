using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.PartyRoleDTO
{
	public class CreatePartyRoleDto
	{
		public string RoleName { get; set; }  // اسم الدور
		public string Description { get; set; }  // وصف الدور
		public string RoleCode { get; set; }
	}
}
