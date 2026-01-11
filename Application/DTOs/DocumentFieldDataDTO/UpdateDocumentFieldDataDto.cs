using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.DocumentFieldDataDTO
{
    public class UpdateDocumentFieldDataDto
    {
		public Guid Id { get; set; }
		public Guid DocumentId { get; set; }  // معرف الوثيقة (Foreign Key)
		
		public string FieldName { get; set; }  // اسم الحقل (Primary Key)

		public string FieldValue { get; set; }  // قيمة النص المدخل (NOT NULL)

	}
}
