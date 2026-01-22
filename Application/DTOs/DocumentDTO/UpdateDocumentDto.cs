using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.DocumentDTO
{
    public class UpdateDocumentDto
    {
		public Guid Id { get; set; }
		public Guid TemplateId { get; set; }  // معرف القالب (Foreign Key)

		public Guid EditorId { get; set; }  // معرف المحرر (Foreign Key)

		public string Code { get; set; }  // رمز الوثيقة
		public DateTime IssueDate { get; set; }  // تاريخ ووقت الإصدار

		public string DocumentStatus { get; set; }  // حالة الوثيقة
		public string Notes { get; set; }  // ملاحظات
		public int AuthenticationNumber { get; set; }  // رقم التصديق
		public string Clause { get; set; }  // البنود

		public string CertificationLocation { get; set; }  // موقع التوثيق
		public ICollection<Guid> ContractPartyIds { get; set; }  // معرفات الأطراف )

		public ICollection<Guid> AttachmentIds { get; set; }  // معرفات المرفقات )
	}
}
