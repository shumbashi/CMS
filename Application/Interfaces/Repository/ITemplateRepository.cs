using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface ITemplateRepository : IRepository<Template>
		{
			// أضف أي وظائف مخصصة لـ Template إذا لزم الأمر
		}
	

}
