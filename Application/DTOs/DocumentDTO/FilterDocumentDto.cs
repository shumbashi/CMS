using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.DocumentDTO
{
	public class FilterDocumentDto
	{
		public string TemplateName { get; set; }
		public string EditorName { get; set; }
		public string DocumentStatus { get; set; }
		public int AuthenticationNumber { get; set; }  // رقم التصديق
		public string Clause { get; set; }  // البنود
		public string Code { get; set; }  // رمز الوثيقة
		public string InspectionNumber { get; set; }
		public string SealNumber { get; set; }
		public string DecisionNumber { get; set; }
	}
}
