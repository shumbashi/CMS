using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class DocumentFieldData : BaseEntity, IAggregateRoot
	{
		public Guid DocumentId { get; set; }  // معرف الوثيقة (Foreign Key)
		public Document Document { get; set; }  // العلاقة مع الوثيقة

		public string FieldName { get; set; }  // اسم الحقل (Primary Key)

		public string FieldValue { get; set; }  // قيمة النص المدخل (NOT NULL)

		
	}
}
