using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.DocumentDTO
{
    public class DocumentDto
    {
		public Guid Id { get; set; }
		public Guid TemplateId { get; set; }  // معرف القالب (Foreign Key)
		public Guid EditorId { get; set; }  // معرف المحرر (Foreign Key)

		public DateTime IssueDate { get; set; }  // تاريخ ووقت الإصدار

		public string DocumentStatus { get; set; }  // حالة الوثيقة

		public int AuthenticationNumber { get; set; }  // رقم التصديق

		public string CertificationLocation { get; set; }  // موقع التوثيق
	}
}
