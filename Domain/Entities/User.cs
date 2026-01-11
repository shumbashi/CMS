using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Domain.Entities
{
	public class User : BaseEntity, IAggregateRoot
	{

		public string Name { get; set; }  // اسم المستخدم

		public string Email { get; set; }  // البريد الإلكتروني

		public string Password { get; set; }  // كلمة المرور

		public string Phone { get; set; }  // رقم الهاتف

		// العلاقة مع المحرر (Editor)
		public Guid? EditorId { get; set; }  // اختيارية، إذا كان المستخدم محررًا
		public Editor Editor { get; set; }  // إذا كان المستخدم محررًا
		public ICollection<Identity> Identities { get; set; }

		public ICollection<UserRole> UserRoles { get; set; }  // علاقة متعدد إلى واحد مع UserRole

		// العلاقة مع الأنشطة
		public ICollection<UserActivity> UserActivities { get; set; }

	}
}
