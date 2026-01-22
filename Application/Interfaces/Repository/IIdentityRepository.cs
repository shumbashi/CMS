using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface IIdentityRepository : IRepository<Identity>
		{
			// أضف أي وظائف مخصصة لـ Identity إذا لزم الأمر
		}


}
