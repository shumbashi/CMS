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
		public class NotificationRepository : Repository<Notification>, INotificationRepository
		{
			private readonly ServiceDbContext _serviceDbContext;

			public NotificationRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
			{
				_serviceDbContext = serviceDbContext;
			}

			// أضف أي وظائف مخصصة لـ Notification هنا إذا لزم الأمر
		}
	}

}
