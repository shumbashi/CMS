using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.ORM;
using Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
	public class PersonsInCompanyRepository : Repository<PersonsInCompany>, IPersonsInCompanyRepository
	{
		private readonly ServiceDbContext _serviceDbContext;

		public PersonsInCompanyRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
		{
			_serviceDbContext = serviceDbContext;
		}

		// أضف أي وظائف مخصصة لـ PersonsInCompany هنا إذا لزم الأمر
	}
}
