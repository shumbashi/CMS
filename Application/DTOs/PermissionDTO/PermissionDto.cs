using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.PermissionDTO
{
    public class PermissionDto
    {
		public Guid Id { get; set; }
		public string Name { get; set; }  // اسم الصلاحية
		public string Description { get; set; }  // وصف الصلاحية
	}
}
