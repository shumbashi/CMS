using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class Company : BaseEntity , IAggregateRoot
	{
	
		public string CompanyName { get; set; } // اسم الشركة
		public string CommercialRecord { get; set; } // السجل التجاري

		public ICollection<PersonsInCompany> PersonsInCompany { get; set; }  // العلاقة مع الأشخاص في الشركة
	}
}
