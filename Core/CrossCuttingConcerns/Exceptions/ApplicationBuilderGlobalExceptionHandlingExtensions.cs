using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public static class ApplicationBuilderGlobalExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionBuilder(this IApplicationBuilder app)
        {
           return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
