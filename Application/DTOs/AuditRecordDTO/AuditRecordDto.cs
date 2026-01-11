using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.AuditRecordDTO
{
	public class AuditRecordDto
    {
		public Guid Id { get; set; }  // معرف السجل
		public Guid UserId { get; set; }  // معرف المستخدم (Foreign Key)
		public string ActionType { get; set; }  // نوع الإجراء

		public DateTime ActionDate { get; set; }  // تاريخ ووقت الإجراء

		public string IpAddress { get; set; }  // عنوان IP للجهاز

		public string AffectedEntityName { get; set; }  // اسم الكيان المتأثر

		public Guid AffectedEntityId { get; set; }  // معرف الكيان المتأثر (الآن GUID)

		public string ChangeDetails { get; set; }  // تفاصيل التغيير
	}
}
