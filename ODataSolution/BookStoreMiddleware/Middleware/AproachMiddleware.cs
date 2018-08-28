using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;

namespace BookStoreMiddleware.Middleware
{
    public class AproachMiddleware
    {
        private readonly ILogger<AproachMiddleware> _logger;
        private readonly RequestDelegate _next;

        public AproachMiddleware(ILogger<AproachMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Keys.Contains("user-key"))
            {
                context.Response.StatusCode = 400; //Bad Request                
                await context.Response.WriteAsync("User Key is missing");
                return;
            }
            else
            //{
            //    if (!ContactsRepo.CheckValidUserKey(context.Request.Headers["user-key"]))
            //    {
            //        context.Response.StatusCode = 401; //UnAuthorized
            //        await context.Response.WriteAsync("Invalid User Key");
            //        return;
            //    }
            //}
            await _next(context);
        }

        public async Task Invoke2(HttpContext context)
        {
            try
            {
                var request = await FormatRequest(context.Request);
                _logger.LogInformation($"{request}");
                await _next(context);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"The following error happened: {ex.Message}");
                throw;
            }

        }     
	
        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;
            request.EnableRewind();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body = body;

            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
        }
    }
}
