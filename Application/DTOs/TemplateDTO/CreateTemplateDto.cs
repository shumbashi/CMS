using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.TemplateDTO
{
    public class CreateTemplateDto
    {
	
		public string TemplateName { get; set; }  // اسم القالب (Unique)

		public string TemplateStatus { get; set; }  // حالة القالب
	}
}
