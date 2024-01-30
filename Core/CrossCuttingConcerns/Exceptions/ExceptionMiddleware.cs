using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;
using System.Runtime.CompilerServices;


namespace Core.CrossCuttingConcerns.Exceptions
{
    // Middleware'ler arasında bir sonrali adıma geçişi sağlar.
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private Task createNotFoundProblemDetailsResponse(
       HttpContext httpContext,
       NotFoundException notFoundException
   )
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

            NotFoundProblemDetails notFoundProblemDetails =
                new()
                {
                    Title = "Not Found",
                    Type = "https://doc.rentacar.com/not-found",
                    Status = StatusCodes.Status404NotFound,
                    Detail = notFoundException.Message,
                    Instance = httpContext.Request.Path
                };
            return httpContext.Response.WriteAsync(notFoundProblemDetails.ToString());
        }

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
            if (exception is ValidationException validationException)
                return createValidationProblemDetailsResponse(httpContext, validationException);

            return createInternalProblemDetailsResponse(httpContext, exception);

        }
        private Task createValidationProblemDetailsResponse(
       HttpContext httpContext,
       ValidationException validationException
   )
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            ValidationProblemDetails validationProblemDetails =
                new(
                    type: "https://doc.rentacar.com/validation-error",
                    title: "Validation Error",
                    instance: httpContext.Request.Path,
                    detail: "Please refer to the errors property for additional details.",
                    errors: validationException
                        .Errors.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                        .ToDictionary(
                            failureGroup => failureGroup.Key,
                            failureGroup => failureGroup.ToArray()
                        )
                )
                {
                    Status = StatusCodes.Status400BadRequest
                };
            return httpContext.Response.WriteAsync(validationProblemDetails.ToString());
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
           ProblemDetails problemDetails = new()
            {
                Title = "Internal Server Error",
                Type = "https://doc.RentACar.com/internal",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }
    }
}
