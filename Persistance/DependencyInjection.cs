using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.StudentsPortal;

namespace Persistance
{

    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentsPortalContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(StudentsPortalContext).Assembly.FullName)));
                   

            services.AddScoped<IStudentsPortalContext>(provider => provider.GetService<StudentsPortalContext>());


            return services;
        }
    }
}
