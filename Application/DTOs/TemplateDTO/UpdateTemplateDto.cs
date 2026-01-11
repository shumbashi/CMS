using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.TemplateDTO
{
    public class UpdateTemplateDto
    {
		public Guid Id { get; set; }  // معرف القالب
		public string TemplateName { get; set; }  // اسم القالب (Unique)

		public string TemplateStatus { get; set; }  // حالة القالب
	}
}
