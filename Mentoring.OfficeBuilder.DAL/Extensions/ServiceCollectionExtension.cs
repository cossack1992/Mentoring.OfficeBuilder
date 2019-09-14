using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mentoring.OfficeBuilder.DAL.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOfficeDbDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<OfficeDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
