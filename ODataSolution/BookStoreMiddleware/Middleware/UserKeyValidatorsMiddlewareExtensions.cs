using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace BookStoreMiddleware.Middleware
{
    public static class UserKeyValidatorsMiddlewareExtensions
    {
        public static IApplicationBuilder UserKeyValidationMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<UserKeyValidatorsMiddleware>();
            return app;
        }
    }
}
