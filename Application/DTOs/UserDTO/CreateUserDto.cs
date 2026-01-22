using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.UserDTO
{
    public class CreateUserDto
    {
		public string Name { get; set; }  // اسم المستخدم

		public string Email { get; set; }  // البريد الإلكتروني

		public string Password { get; set; }  // كلمة المرور

		public bool Active { get; set; }  // حالة النشاط (نشط أو غير نشط)

		public string Phone { get; set; }  // رقم الهاتف

		public Guid? EditorId { get; set; }
	}
}
