using Application.Interfaces;
using Application.Interfaces.Common;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ORM
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
           

            return services;
        }
    }
}
