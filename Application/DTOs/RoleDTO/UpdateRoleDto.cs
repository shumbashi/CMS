using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.RoleDTO
{
    public class UpdateRoleDto
    {
		public Guid Id { get; set; }
		public string Name { get; set; }  // اسم الدور
		public string Description { get; set; }  // وصف الدور
	}
}
