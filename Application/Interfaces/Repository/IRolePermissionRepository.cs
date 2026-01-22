using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface IRolePermissionRepository : IRepository<RolePermission>
		{
			// أضف أي وظائف مخصصة لـ RolePermission إذا لزم الأمر
		}
	

}
