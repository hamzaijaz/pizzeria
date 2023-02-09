using pizzeriaserver.Application.Common.Exceptions;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace pizzeriaserver.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var result = SerializeObject(new[] { ex.Message });
                await context.Response.WriteAsync(result);
            }
            catch (BadRequestException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var result = SerializeObject(new[] { ex.Message });
                await context.Response.WriteAsync(result);
            }
            catch (DuplicateItemException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                var result = SerializeObject(new[] { ex.Message });
                await context.Response.WriteAsync(result);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var result = SerializeObject(new[] { ex.Message });
                await context.Response.WriteAsync(result);
            }
        }

        private static string SerializeObject(object obj)
            => JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(true, true)
                }
            });
    }
}
