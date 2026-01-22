using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface IAuditRecordRepository : IRepository<AuditRecord>
		{
			// أضف أي وظائف مخصصة لـ AuditRecord إذا لزم الأمر
		}
	
}
