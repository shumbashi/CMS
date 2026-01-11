using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class PartyRole : BaseEntity , IAggregateRoot
	{
		public Guid ContractPartyId { get; set; }
		public ContractParty ContractParty { get; set; }
		public string RoleName { get; set; }  // اسم الدور (مثل بائع، مشتري، وكيل)
		public string RoleCode { get; set; }  // كود الدور (اختياري)
	}
}
