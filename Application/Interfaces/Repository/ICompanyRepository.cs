using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface ICompanyRepository : IRepository<Company>
		{
			// أضف أي وظائف مخصصة لـ Company إذا لزم الأمر
		}
	

}
