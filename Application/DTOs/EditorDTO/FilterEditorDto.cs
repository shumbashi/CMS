using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.EditorDTO
{
	public class FilterEditorDto
	{
		public string EditorName { get; set; }  // اسم المحرر (فلترة بواسطة اسم المحرر)
		public string InspectionNumber { get; set; }  // رقم قيد التفتيش
		public string SealNumber { get; set; }  // رقم الختم الإلكتروني
		public string DecisionNumber { get; set; }  // قرار الرقم
		public string CourtDivision { get; set; }  // دائرة المحكمة
		public decimal? MinFinancialBalance { get; set; }  // أقل رصيد مالي للفلترة
		public decimal? MaxFinancialBalance { get; set; }  // أكبر رصيد مالي للفلترة
	}
}
