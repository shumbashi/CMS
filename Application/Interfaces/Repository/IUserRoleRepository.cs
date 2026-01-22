using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface IUserRoleRepository : IRepository<UserRole>
		{
			// أضف أي وظائف مخصصة لـ UserRole إذا لزم الأمر
		}
	

}
