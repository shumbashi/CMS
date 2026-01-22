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
		public class ContractPartyInDocumentRepository : Repository<ContractPartyInDocument>, IContractPartyInDocumentRepository
		{
			private readonly ServiceDbContext _serviceDbContext;

			public ContractPartyInDocumentRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
			{
				_serviceDbContext = serviceDbContext;
			}

			// أضف أي وظائف مخصصة لـ ContractPartyInDocument هنا إذا لزم الأمر
		}
	}

}
