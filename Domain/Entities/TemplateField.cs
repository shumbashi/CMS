using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class TemplateField : BaseEntity, IAggregateRoot
	{
		public Guid TemplateId { get; set; }  // معرف القالب (Foreign Key)
		public Template Template { get; set; }  // العلاقة مع القالب

		public string FieldName { get; set; }  // اسم الحقل (Primary Key)

		public string ExpectedDataType { get; set; }  // نوع البيانات المتوقعة

		public string FieldDescription { get; set; }  // وصف الحقل
	}
}
