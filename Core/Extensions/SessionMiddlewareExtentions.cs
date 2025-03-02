using Core.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    /// <summary>
    /// Contains extension methods for the session middleware.
    /// </summary>
    public static class SessionMiddlewareExtentions
    {
        /// <summary>
        /// Configures the session middleware.
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureSessionMiddlewareExtentions(this IApplicationBuilder app)
        {
            app.UseMiddleware<SessionMiddleware>();
        }
    }
}
