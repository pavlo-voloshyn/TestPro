using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;

namespace TestPro.Api.Helpers
{
    public static class ConfigureGlobalExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        HttpStatusCode statusCode;
                        var exception = contextFeature.Error;

                        if (exception is ArgumentException || exception is FormatException)
                        {
                            statusCode = HttpStatusCode.BadRequest;
                        }
                        else if (exception is ArgumentNullException)
                        {
                            statusCode = HttpStatusCode.NotFound;
                        }
                        else if (exception is InvalidOperationException)
                        {
                            statusCode = HttpStatusCode.MethodNotAllowed;
                        }
                        else
                        {
                            statusCode = HttpStatusCode.InternalServerError;
                        }
                        context.Response.StatusCode = (int)statusCode;
                        context.Response.ContentType = "application/json";
                        string result = JsonConvert.SerializeObject(exception);
                        await context.Response.WriteAsync(result);
                    }
                });
            });

        }
    }
}
