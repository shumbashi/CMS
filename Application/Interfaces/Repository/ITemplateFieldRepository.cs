using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface ITemplateFieldRepository : IRepository<TemplateField>
		{
			// أضف أي وظائف مخصصة لـ TemplateField إذا لزم الأمر
		}
	

}
