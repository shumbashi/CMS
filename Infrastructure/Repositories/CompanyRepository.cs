using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.ORM;
using Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
	namespace Infrastructure.Repositories
	{
		public class CompanyRepository : Repository<Company>, ICompanyRepository
		{
			private readonly ServiceDbContext _serviceDbContext;

			public CompanyRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
			{
				_serviceDbContext = serviceDbContext;
			}

			// أضف أي وظائف مخصصة لـ Company هنا إذا لزم الأمر
		}
	}

}
