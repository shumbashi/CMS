using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Editor : BaseEntity , IAggregateRoot
	{
		public string EditorName { get; set; }
		public string InspectionNumber { get; set; }  // رقم قيد التفتيش

		public string SealNumber { get; set; }  // رقم الختم الإلكتروني

		public string DecisionNumber { get; set; }  // قرار الرقم

		public string CourtDivision { get; set; }  // دائرة المحكمة

		public decimal FinancialBalance { get; set; }  // الرصيد المالي

		public ICollection<Document> Documents { get; set; }  // علاقة متعددة إلى متعددة
															  // العلاقة مع الهوية (Identity)
		public Guid IdentityId { get; set; }  // مفتاح خارجي لربط المحرر بالهوية
		public Identity Identity { get; set; }  // العلاقة مع الهوية
												
		public Guid UserId { get; set; }
		public User User { get; set; }  // العلاقة مع المستخدم
		
	}
}
