
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Common
{
	public class BCryptPasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
	{
		public string HashPassword(TUser user, string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password);
		}

		public PasswordVerificationResult VerifyHashedPassword(
			TUser user,
			string hashedPassword,
			string providedPassword)
		{
			bool ok = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);

			return ok
				? PasswordVerificationResult.Success
				: PasswordVerificationResult.Failed;
		}
	}
}
