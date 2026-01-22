using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.UserRoleDTO
{
    public class UpdateUserRoleDto
    {
		public Guid Id { get; set; }
		public Guid RoleId { get; set; }  // معرف الدور
	}
}
