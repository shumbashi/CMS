using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.ORM;
using Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
	
		public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
		{
			private readonly ServiceDbContext _serviceDbContext;

			public UserRoleRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
			{
				_serviceDbContext = serviceDbContext;
			}

			// أضف أي وظائف مخصصة لـ UserRole هنا إذا لزم الأمر
		}
	}


