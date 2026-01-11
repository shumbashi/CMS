using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Document : BaseEntity, IAggregateRoot
	{
		public string Code { get; set; }  // رمز الوثيقة
		public DateTime IssueDate { get; set; }  // تاريخ الإصدار

		public string DocumentStatus { get; set; }  // حالة الوثيقة
		public string Notes { get; set; }  // ملاحظات

		public int AuthenticationNumber { get; set; }  // رقم التصديق

		public string Clause { get; set; }  // البنود

		public Guid TemplateId { get; set; }  // معرف القالب (Foreign Key)
		public Template Template { get; set; }  // العلاقة مع القالب

		public Guid EditorId { get; set; }  // معرف المحرر (Foreign Key)
		public Editor Editor { get; set; }  // العلاقة مع المحرر

		// علاقة متعدد إلى متعدد مع الأطراف عبر جدول ContractPartyInDocument
		public ICollection<ContractPartyInDocument> ContractPartyInDocuments { get; set; }  // علاقة مع الأطراف

		// إضافة المرفقات
		public List<Attachment> Attachments { get; set; }
	}
}
