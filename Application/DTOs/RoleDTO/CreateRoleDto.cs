using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.RoleDTO
{
    public class CreateRoleDto
    {
		public string Name { get; set; }  // اسم الدور
		public string Description { get; set; }  // وصف الدور
	}
}
