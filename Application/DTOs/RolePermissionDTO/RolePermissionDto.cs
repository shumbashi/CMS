using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.RolePermissionDTO
{
    public class RolePermissionDto
    {
		public Guid Id { get; set; }
		public Guid RoleId { get; set; }  // معرف الدور
		public string RoleName { get; set; }  // اسم الدور
		public Guid PermissionId { get; set; }  // معرف الصلاحية
		public string PermissionName { get; set; }  // اسم الصلاحية
	}
}
