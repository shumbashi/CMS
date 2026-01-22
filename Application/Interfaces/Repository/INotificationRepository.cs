using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface INotificationRepository : IRepository<Notification>
		{
			// أضف أي وظائف مخصصة لـ Notification إذا لزم الأمر
		}
	

}
