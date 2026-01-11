using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Permission : BaseEntity, IAggregateRoot
	{
		public string Name { get; set; }  // اسم الصلاحية (مثل: "قراءة"، "كتابة")
		public string Description { get; set; }  // وصف الصلاحية
	}
}
