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

		public bool Active { get; set; }  // حالة النشاط (نشط أو غير نشط)

		public string Phone { get; set; }  // رقم الهاتف

		public int NationalNumber { get; set; }  // الرقم الوطني

		
	}
}
