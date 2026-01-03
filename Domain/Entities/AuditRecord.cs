using Domain.Common;
using System;

namespace Domain.Entities
{
	public class AuditRecord : BaseEntity, IAggregateRoot
	{

		public Guid UserId { get; set; }  // معرف المستخدم (Foreign Key)
		public User User { get; set; }  // العلاقة مع المستخدم

		public string ActionType { get; set; }  // نوع الإجراء

		public DateTime ActionDate { get; set; }  // تاريخ ووقت الإجراء

		public string IpAddress { get; set; }  // عنوان IP للجهاز

		public string AffectedEntityName { get; set; }  // اسم الكيان المتأثر

		public Guid AffectedEntityId { get; set; }  // معرف الكيان المتأثر (الآن GUID)

		public string ChangeDetails { get; set; }  // تفاصيل التغيير
	}
}
