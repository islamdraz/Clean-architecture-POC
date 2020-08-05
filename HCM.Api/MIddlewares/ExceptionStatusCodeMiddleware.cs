using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Common.CustomValidations;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HCM.Api.MIddlewares
{
    public class ExceptionStatusCodeMiddleware
    {
        private RequestDelegate _Next;

        public ExceptionStatusCodeMiddleware(RequestDelegate next)
        {
            _Next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
              await  _Next(context);
            //  throw new ValidationException("this is my exception");
            }
            catch (RequestInValidException e)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(e.ErrorCodes));

            }
            catch (Exception e)
            {
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"[ \"{e.Message}\" , \"{e.InnerException?.Message}\" ]");
            }
        }
    }

    public static class ExceptionStatusMiddleware
    {
        public static IApplicationBuilder AddExceptionStatusCodeMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionStatusCodeMiddleware>();
        }
    }
}
