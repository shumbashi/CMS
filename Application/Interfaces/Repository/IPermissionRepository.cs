using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface IPermissionRepository : IRepository<Permission>
		{
			// أضف أي وظائف مخصصة لـ Permission إذا لزم الأمر
		}
	

}
