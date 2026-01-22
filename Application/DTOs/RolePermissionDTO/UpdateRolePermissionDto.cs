using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.RolePermissionDTO
{
    public class UpdateRolePermissionDto
    {
		public Guid Id { get; set; }
		public Guid RoleId { get; set; }  // معرف الدور
		public Guid PermissionId { get; set; }  // معرف الصلاحية
	
	}
}
