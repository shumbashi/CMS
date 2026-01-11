using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class UserActivity : BaseEntity, IAggregateRoot
	{
		public Guid UserId { get; set; }  // معرف المستخدم
		public User User { get; set; }  // العلاقة مع جدول المستخدم

		public string Activity { get; set; }  // نوع النشاط (مثل: "تسجيل الدخول"، "تعديل الملف الشخصي")
		public DateTime Date { get; set; }  // تاريخ النشاط
	}
}
