using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.AttachmentDTO
{
    public class CreateAttachmentDto
    {
        public Guid DocumentId { get; set; }  // معرف الوثيقة (Foreign Key)
        public string AttachmentType { get; set; }  // نوع المرفق
        public DateTime UploadDate { get; set; }  // تاريخ الرفع
        public string StoragePath { get; set; }  // مسار التخزين
        public long FileSize { get; set; }  // حجم المرفق
	}
}
