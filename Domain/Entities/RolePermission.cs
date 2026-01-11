using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class RolePermission : BaseEntity, IAggregateRoot
	{
		public Guid RoleId { get; set; }  // معرف الدور
		public Role Role { get; set; }  // العلاقة مع جدول الأدوار

		public Guid PermissionId { get; set; }  // معرف الصلاحية
		public Permission Permission { get; set; }  // العلاقة مع جدول الصلاحيات
	}
}
