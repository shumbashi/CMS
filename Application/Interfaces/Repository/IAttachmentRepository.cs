using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface IAttachmentRepository : IRepository<Attachment>
		{
			// أضف أي وظائف مخصصة لـ Attachment إذا لزم الأمر
		}
	

}
