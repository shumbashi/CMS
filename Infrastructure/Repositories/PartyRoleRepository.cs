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
		public class PartyRoleRepository : Repository<PartyRole>, IPartyRoleRepository
		{
			private readonly ServiceDbContext _serviceDbContext;

			public PartyRoleRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
			{
				_serviceDbContext = serviceDbContext;
			}

			// أضف أي وظائف مخصصة لـ PartyRole هنا إذا لزم الأمر
		}
	}

}
