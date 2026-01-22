using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.CompanyDTO
{
	public class CreateCompanyDto
	{
		public string CompanyName { get; set; }  // اسم الشركة
		public string CommercialRecord { get; set; }  // السجل التجاري
	}
}
