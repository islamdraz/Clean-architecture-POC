using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using HCM.Api.MIddlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistance;

namespace HCM.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApplication(Configuration);
            services.AddPersistance(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//,ILoggerFactory loggerFactory
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region middleware play around

            //var logger = loggerFactory.CreateLogger("My logger ");

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation($"start of the request {env.EnvironmentName}");
            //   await next();

            //});

            //   app.Map("/Contacts",  a=>a.Run(async context => { await context.Response.WriteAsync("hello here is the contacts "); }));

            // app.MapWhen(context => context.Request.Headers["User-Agent"].First().Contains("Chrome"), HelloChrome);

            #endregion
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.AddExceptionStatusCodeMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void HelloChrome(IApplicationBuilder app)
        {
            app.Run(async context=> await context.Response.WriteAsync("hello from chrome"));
        }
    }
}
