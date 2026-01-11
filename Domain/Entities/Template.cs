using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Template : BaseEntity, IAggregateRoot
	{
		

		public string TemplateName { get; set; }  // اسم القالب (Unique)

		public string TemplateStatus { get; set; }  // حالة القالب

		public ICollection<Document> Documents { get; set; }  // علاقة متعدد إلى واحد مع Document

	}
}
