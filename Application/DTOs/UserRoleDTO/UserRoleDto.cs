using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.UserRoleDTO
{
    public class UserRoleDto
    {
		public Guid Id { get; set; }  // معرف المستخدم والدور
		public Guid UserId { get; set; }  // معرف المستخدم
		public Guid RoleId { get; set; }  // معرف الدور
	}
}
