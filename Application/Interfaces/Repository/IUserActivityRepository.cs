using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface IUserActivityRepository : IRepository<UserActivity>
		{
			// أضف أي وظائف مخصصة لـ UserActivity إذا لزم الأمر
		}
	

}
