using Mentoring.OfficeBuilder.DAL.Services;
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
        private static IServiceCollection AddOfficeDbDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<OfficeDbContext>(option => 
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static IServiceCollection AddDALContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOfficeDbDbContext(configuration);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
