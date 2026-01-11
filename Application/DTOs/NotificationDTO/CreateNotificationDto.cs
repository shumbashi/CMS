using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.NotificationDTO
{
    public class CreateNotificationDto
    {
		public Guid SenderId { get; set; }  // معرف المرسل (Foreign Key)

		public string NotificationType { get; set; }  // نوع التنبيه

		public string NotificationTitle { get; set; }  // عنوان التنبيه

		public DateTime SendDate { get; set; }  // تاريخ الإرسال

		public string Content { get; set; }  // محتوى التنبيه
	}
}
