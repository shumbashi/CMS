using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.ORM;
using Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
	public class RoleRepository : Repository<Role>, IRoleRepository
	{
		private readonly ServiceDbContext _serviceDbContext;

		public RoleRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
		{
			_serviceDbContext = serviceDbContext;
		}

		// أضف أي وظائف مخصصة لـ Role هنا إذا لزم الأمر
	}
}

