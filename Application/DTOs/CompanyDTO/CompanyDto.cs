using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.CompanyDTO
{
	public class CompanyDto
	{
		public Guid Id { get; set; }  // معرف الشركة
		public string CompanyName { get; set; }  // اسم الشركة
		public string CommercialRecord { get; set; }  // السجل التجاري
	}
}
