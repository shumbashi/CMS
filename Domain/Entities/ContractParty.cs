using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class ContractParty : BaseEntity, IAggregateRoot
	{
		

		public string ContractPartyType { get; set; }  // نوع الطرف
		public string ContractPartyName { get; set; }  // اسم الطرف

		public string Representative { get; set; }  // الممثل أو النائب

		public string Nationality { get; set; }  // الجنسية

		public string PhoneNumber { get; set; }  // رقم الهاتف (NOT NULL)

		public string Residence { get; set; }  // محل الإقامة (NOT NULL)

		public DateTime BirthDate { get; set; }  // تاريخ الميلاد

		public string NationalId { get; set; }  // الرقم الوطني / التجاري

		public string IdentityProof { get; set; }  // إثبات الهوية
	}
}
