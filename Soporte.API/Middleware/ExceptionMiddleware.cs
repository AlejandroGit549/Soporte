using Newtonsoft.Json;
using Soporte.Application.Exceptions;
using Soporte.Application.Models.Common;
using System.Net;

namespace Soporte.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (ex)
            {
                case NotFoundException notFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;

                case ValidationException validationException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                    result = JsonConvert.SerializeObject(new Response<string>
                    {
                        Message= ex.Message + Environment.NewLine + validationJson,
                        StatusCode = (short)statusCode,
                        Success = false,
                    });
                    break;

                case BadRequestException badRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    break;
            }

            if (string.IsNullOrEmpty(result))
                result = JsonConvert.SerializeObject(new Response<string>
                {
                    Message  = ex.Message +Environment.NewLine+ex.StackTrace,
                    StatusCode = (short)statusCode,
                    Success = false,
                });


            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(result);

        }

    }
}
