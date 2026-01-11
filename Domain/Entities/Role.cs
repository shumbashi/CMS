using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Role : BaseEntity, IAggregateRoot
	{
		public string Name { get; set; }  // اسم الدور (مثل: مستخدم، مشرف)
		public string Description { get; set; }  // وصف الدور
		public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
		public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
	}
}
