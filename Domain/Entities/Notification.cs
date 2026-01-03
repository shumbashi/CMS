using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Notification : BaseEntity, IAggregateRoot
	{
		public Guid SenderId { get; set; }  // معرف المرسل (Foreign Key)
		public User Sender { get; set; }  // العلاقة مع المرسل

		public string NotificationType { get; set; }  // نوع التنبيه

		public string NotificationTitle { get; set; }  // عنوان التنبيه

		public DateTime SendDate { get; set; }  // تاريخ الإرسال

		public string Content { get; set; }  // محتوى التنبيه
	}
}
