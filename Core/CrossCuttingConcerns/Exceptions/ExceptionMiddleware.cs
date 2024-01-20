using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Mime;
using System.Runtime.CompilerServices;


namespace Core.CrossCuttingConcerns.Exceptions
{
    // Middleware'ler arasında bir sonrali adıma geçişi sağlar.
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            
            //Delegate : Bir kod bütününü temsil eder.
            //RequestDelegate : Bir HTTP Request akışındaki bir sonrali adımı temsil eder.
        
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //HttpContext: Bir Http Request akışını temsil eder.
            //Asynchronous: Eş zamanlı programlama.
            //async: Bir metodu eş zamanlı hale getirir. Await kullanılcaksa eklenmesi gerekir.
            //task : bir asenkron işlemi temsil eder.

            try
            {
                //AddBrandResponse response = _brandService.Add(request);
                //return CreatedAtAction(nameof(GetList), response); //201 Created
                // Örnek olarak add endpoint metodundali kodların referansı _next'tedir.
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await handleExceptionAsync(httpContext, exception);
                //await bir sonraki adımın tamamlanmasını bekler.
            }
            
        }
        private Task handleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;

            //if(exception.GetType() == typeof(BusinessException))
            //{
            //    BusinessException businessException = (BusinessException)exception; //casting
            //    return createBusinessProblemDetailsResponse(httpContext, businessException);
            //}

            if(exception is BusinessException businessException) 
                return createBusinessProblemDetailsResponse(httpContext, businessException);
            
            return createInternalProblemDetailsResponse(httpContext, exception);

        }
        private Task createBusinessProblemDetailsResponse(
            HttpContext httpContext,
            BusinessException exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            BusinessProblemDetails businessProblemDetails = new()
            {
                Title = "Business Extencion",
                Type = "https://doc.RentACar.com/brands",
                Status = StatusCodes.Status400BadRequest,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };
            return httpContext.Response.WriteAsync(businessProblemDetails.ToString());
            
        }
        private Task createInternalProblemDetailsResponse(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
           BusinessProblemDetails problemDetails = new()
            {
                Title = "Internal Extencion",
                Type = "https://doc.RentACar.com/brands",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }
    }
}
