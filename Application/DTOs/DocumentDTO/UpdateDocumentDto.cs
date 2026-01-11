using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.DocumentDTO
{
    public class UpdateDocumentDto
    {
		public Guid Id { get; set; }

		public DateTime IssueDate { get; set; }  // تاريخ ووقت الإصدار

		public string DocumentStatus { get; set; }  // حالة الوثيقة

		public int AuthenticationNumber { get; set; }  // رقم التصديق

		public string CertificationLocation { get; set; }  // موقع التوثيق
	}
}
