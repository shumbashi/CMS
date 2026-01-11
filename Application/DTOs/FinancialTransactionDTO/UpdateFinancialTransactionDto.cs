using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.FinancialTransactionDTO
{
    public class UpdateFinancialTransactionDto
    {
		public Guid Id { get; set; }
		public Guid UserId { get; set; }  // معرف المستخدم (Foreign Key)
	
		public Guid DocumentId { get; set; }  // معرف الوثيقة (Foreign Key)
		
		public string TransactionStatus { get; set; }  // حالة العملية

		public string TransactionType { get; set; }  // نوع المعاملة

		public DateTime TransactionDate { get; set; }  // تاريخ المعاملة

		public decimal Amount { get; set; }  // المبلغ
	}
}
