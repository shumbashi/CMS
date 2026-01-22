using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.ORM;
using Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
	public class RolePermissionRepository : Repository<RolePermission>, IRolePermissionRepository
	{
		private readonly ServiceDbContext _serviceDbContext;

		public RolePermissionRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
		{
			_serviceDbContext = serviceDbContext;
		}

		// أضف أي وظائف مخصصة لـ RolePermission هنا إذا لزم الأمر
	}
}
