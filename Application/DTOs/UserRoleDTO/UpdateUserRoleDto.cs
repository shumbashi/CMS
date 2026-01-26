using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.UserRoleDTO
{
    public class UpdateUserRoleDto
    {
		public Guid Id { get; set; }
		public Guid UserId { get; set; }  // معرف المستخدم
		public Guid RoleId { get; set; }  // معرف الدور
		public Guid AssignedById { get; set; }
	}
}
