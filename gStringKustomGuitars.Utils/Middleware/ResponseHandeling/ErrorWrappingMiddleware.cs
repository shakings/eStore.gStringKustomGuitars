using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace gStringKustomGuitars.Utils.Middleware.ResponseHandeling
{
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorWrappingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string Message = string.Empty;
            try
            {
                await _next.Invoke(context);
            }
            catch (TimeoutException ex)
            {
                Log.Error(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                Message = "Operation has timed out";
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.Error(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                Message = ex.Message;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                Message = "An unknown error has occured";
            }
        }
    }
}
