using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMiddleware.Middleware
{
    public static class AproachMiddlewareExtensions
    {
        public static IApplicationBuilder UseApproachMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AproachMiddleware>();
        }
    }
}
