using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.ORM;
using Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
	public class UserActivityRepository : Repository<UserActivity>, IUserActivityRepository
	{
		private readonly ServiceDbContext _serviceDbContext;

		public UserActivityRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
		{
			_serviceDbContext = serviceDbContext;
		}

		// أضف أي وظائف مخصصة لـ UserActivity هنا إذا لزم الأمر
	}
}

