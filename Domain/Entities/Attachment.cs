using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Attachment : BaseEntity, IAggregateRoot
	{
		

		public Guid DocumentId { get; set; }  // معرف الوثيقة (Foreign Key)
		public Document Document { get; set; }  // العلاقة مع الوثيقة

		public string AttachmentType { get; set; }  // نوع المرفق

		public DateTime UploadDate { get; set; }  // تاريخ الرفع

		public string StoragePath { get; set; }  // مسار التخزين

		public long FileSize { get; set; }  // حجم المرفق
	}
}
