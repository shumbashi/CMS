using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.ORM;
using Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
	public class PermissionRepository : Repository<Permission>, IPermissionRepository
	{
		private readonly ServiceDbContext _serviceDbContext;

		public PermissionRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
		{
			_serviceDbContext = serviceDbContext;
		}

		// أضف أي وظائف مخصصة لـ Permission هنا إذا لزم الأمر
	}
}
