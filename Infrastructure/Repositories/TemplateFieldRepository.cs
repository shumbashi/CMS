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
		public class TemplateFieldRepository : Repository<TemplateField>, ITemplateFieldRepository
		{
			private readonly ServiceDbContext _serviceDbContext;

			public TemplateFieldRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
			{
				_serviceDbContext = serviceDbContext;
			}

			// أضف أي وظائف مخصصة لـ TemplateField هنا إذا لزم الأمر
		}
	}

}
