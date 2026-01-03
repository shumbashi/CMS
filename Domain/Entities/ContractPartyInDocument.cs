using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ContractPartyInDocument : BaseEntity, IAggregateRoot
	{
		public Guid DocumentId { get; set; }  // معرف الوثيقة (Foreign Key)
		public Document Document { get; set; }  // العلاقة مع الوثيقة

		public string ContractPartyRole { get; set; }  // دور الطرف (طرف في الوثيقة)
	}
}
