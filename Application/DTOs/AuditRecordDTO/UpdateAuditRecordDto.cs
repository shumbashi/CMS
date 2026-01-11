using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.AuditRecordDTO
{
    public class UpdateAuditRecordDto
    {
		public Guid Id { get; set; }  // معرف السجل
		public string ActionType { get; set; }  // نوع الإجراء

		public DateTime ActionDate { get; set; }  // تاريخ ووقت الإجراء

		public string IpAddress { get; set; }  // عنوان IP للجهاز

		public string AffectedEntityName { get; set; }  // اسم الكيان المتأثر
		public string ChangeDetails { get; set; }  // تفاصيل التغيير
	}
}
