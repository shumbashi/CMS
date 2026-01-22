
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
		public class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
		{
			private readonly ServiceDbContext _serviceDbContext;

			public AttachmentRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
			{
				_serviceDbContext = serviceDbContext;
			}

			// أضف أي وظائف مخصصة لـ Attachment هنا إذا لزم الأمر
		}
	}

}
