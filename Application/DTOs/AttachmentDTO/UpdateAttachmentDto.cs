using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.AttachmentDTO
{
    public class UpdateAttachmentDto
    {
		public Guid Id { get; set; }
		

		public string AttachmentType { get; set; }  // نوع المرفق

		public DateTime UploadDate { get; set; }  // تاريخ الرفع

		public string StoragePath { get; set; }  // مسار التخزين

		public long FileSize { get; set; }  // حجم المرفق
	}
}
