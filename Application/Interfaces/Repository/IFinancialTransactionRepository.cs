using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
	
		public interface IFinancialTransactionRepository : IRepository<FinancialTransaction>
		{
			// أضف أي وظائف مخصصة لـ FinancialTransaction إذا لزم الأمر
		}
	

}
