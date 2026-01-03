
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ORM
{
    public class ServiceDbContextFactory : IDesignTimeDbContextFactory<ServiceDbContext>
    {
        public ServiceDbContext CreateDbContext(string[] args)
        {
            var connectionString = "server=localhost;port=3306;database=CMS;UID=admin-cms;password=mm28@krhps;CharSet=utf8mb4";

            var optionsBuilder = new DbContextOptionsBuilder<ServiceDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new ServiceDbContext(optionsBuilder.Options);
        }
    
    }
}
