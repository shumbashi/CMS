using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.CompanyDTO
{
	public class UpdateCompanyDto
	{
       
        public Guid Id { get; set; }


        public string? CompanyName { get; set; }
        public string? CommercialRecord { get; set; }

        
    }
}
