using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface IRoleRepository : IRepository<Role>
		{
			// أضف أي وظائف مخصصة لـ Role إذا لزم الأمر
		}
	

}
