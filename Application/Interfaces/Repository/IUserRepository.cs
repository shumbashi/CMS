using Application.Interfaces.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repository
{
		public interface IUserRepository : IRepository<User>
		{
		Task<User?> ValidNameAndEmailAndPhoneAsync(string name, string email, string phone);
	}
	

}
