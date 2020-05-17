using Microsoft.Extensions.DependencyInjection;
using SampleDotNetCoreMVCWithEF.BusinessLogic;
using SampleDotNetCoreMVCWithEF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDotNetCoreMVCWithEF.Helper
{
    public static class DIRegistry
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<CustomerRepository>()
                .AddScoped<CustomerManager>();

            return services;
        }
    }
}
