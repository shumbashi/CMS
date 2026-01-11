using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.UserDTO
{
	public class UserDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }  // اسم المستخدم

		public string Email { get; set; }  // البريد الإلكتروني

		public string Password { get; set; }  // كلمة المرور

		public bool Active { get; set; }  // حالة النشاط (نشط أو غير نشط)

		public string Phone { get; set; }  // رقم الهاتف

		public int NationalNumber { get; set; }  // الرقم الوطني

	}
}
