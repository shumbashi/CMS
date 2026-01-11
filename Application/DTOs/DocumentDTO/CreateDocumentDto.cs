using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.DocumentDTO
{
    public class CreateDocumentDto
    {
		public Guid TemplateId { get; set; }  // معرف القالب (Foreign Key)
		public Template Template { get; set; }  // العلاقة مع القالب

		public Guid EditorId { get; set; }  // معرف المحرر (Foreign Key)
		public Editor Editor { get; set; }  // العلاقة مع المحرر


		public DateTime IssueDate { get; set; }  // تاريخ ووقت الإصدار

		public string DocumentStatus { get; set; }  // حالة الوثيقة

		public int AuthenticationNumber { get; set; }  // رقم التصديق

		public string CertificationLocation { get; set; }  // موقع التوثيق
	}
}
