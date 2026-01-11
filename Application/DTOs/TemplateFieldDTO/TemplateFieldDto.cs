using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.TemplateFieldDTO
{
    public class TemplateFieldDto
    {
		public Guid Id { get; set; }
		public Template Template { get; set; }  // العلاقة مع القالب

		public string FieldName { get; set; }  // اسم الحقل (Primary Key)

		public string ExpectedDataType { get; set; }  // نوع البيانات المتوقعة

		public string FieldDescription { get; set; }  // وصف الحقل
	}
}
