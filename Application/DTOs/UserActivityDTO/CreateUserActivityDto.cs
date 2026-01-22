using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.UserActivityDTO
{
    public class CreateUserActivityDto
    {
		public Guid UserId { get; set; }  // معرف المستخدم
		public string Activity { get; set; }  // النشاط
		public DateTime Date { get; set; }  // تاريخ النشاط
	}
}
