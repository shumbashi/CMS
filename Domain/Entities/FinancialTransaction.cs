using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class FinancialTransaction : BaseEntity, IAggregateRoot
	{
		public Guid UserId { get; set; }  // معرف المستخدم (Foreign Key)
		public User User { get; set; }  // العلاقة مع المستخدم

		public Guid DocumentId { get; set; }  // معرف الوثيقة (Foreign Key)
		public Document Document { get; set; }  // العلاقة مع الوثيقة

		public string TransactionStatus { get; set; }  // حالة العملية

		public string TransactionType { get; set; }  // نوع المعاملة

		public DateTime TransactionDate { get; set; }  // تاريخ المعاملة

		public decimal Amount { get; set; }  // المبلغ
	}
}
