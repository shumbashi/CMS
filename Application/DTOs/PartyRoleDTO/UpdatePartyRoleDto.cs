using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.PartyRoleDTO
{
	public class UpdatePartyRoleDto
	{
		public Guid Id { get; set; }
		public string RoleName { get; set; }  
		public string Description { get; set; }
		public string RoleCode { get; set; }
	}
}
