using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.EditorDTO
{
    public class UpdateEditorDto
    {
		public Guid Id { get; set; }
		public string InspectionNumber { get; set; }  // رقم قيد التفتيش

		public string SealNumber { get; set; }  // رقم الختم الإلكتروني

		public string DecisionNumber { get; set; }  // قرار الرقم

		public string CourtDivision { get; set; }  // دائرة المحكمة

		public DateTime BirthDate { get; set; }  // تاريخ الميلاد

		public decimal FinancialBalance { get; set; }  // الرصيد المالي

		public decimal Length { get; set; }  // الطول

		public decimal Width { get; set; }  // العرض
	}
}
