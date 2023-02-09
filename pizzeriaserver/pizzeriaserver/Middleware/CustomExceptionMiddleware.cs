using pizzeriaserver.Application.Common.Exceptions;
using System.Net;

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
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (BadRequestException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (DuplicateItemException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
