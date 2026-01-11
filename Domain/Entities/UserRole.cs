using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class UserRole : BaseEntity, IAggregateRoot
	{
		public Guid UserId { get; set; }  // معرف المستخدم
		public User User { get; set; }  // العلاقة مع جدول المستخدم

		public Guid RoleId { get; set; }  // معرف الدور
		public Role Role { get; set; }  // العلاقة مع جدول الأدوار

		// المستخدم اللي أعطى هذا الدور
		public Guid AssignedById { get; set; }
		public User AssignedBy { get; set; }
	}
}
