using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.ORM;
using Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
	namespace Infrastructure.Repositories
	{
		public class UserRepository : Repository<User>, IUserRepository
		{
			private readonly ServiceDbContext _serviceDbContext;

			public UserRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
			{
				_serviceDbContext = serviceDbContext;
			}

            public async Task<User?> ValidNameAndEmailAndPhoneAsync(string name, string email, string phone)
            {
				return await _serviceDbContext.Users
						   .AsNoTracking() // نستخدم AsNoTracking لتحسين الأداء عند عدم الحاجة لتتبع الكائنات
						   .FirstOrDefaultAsync(u => u.Name == name || u.Email == email || u.Phone == phone); // التحقق من أي تطابق
			}

		}
	}

}
