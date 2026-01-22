using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface IPersonsInCompanyRepository : IRepository<PersonsInCompany>
		{
			// أضف أي وظائف مخصصة لـ PersonsInCompany إذا لزم الأمر
		}
	

}
