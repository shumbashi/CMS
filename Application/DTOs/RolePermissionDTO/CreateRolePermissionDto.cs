using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.RolePermissionDTO
{
    public class CreateRolePermissionDto
    {
		public Guid RoleId { get; set; }  // معرف الدور
		public Guid PermissionId { get; set; }  // معرف الصلاحية
	}
}
