using System.Net;
using System.Text.Json;
using MasterNet.Application.Core;
using Newtonsoft.Json;

namespace MasterNet.WebApi.Middleware;


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

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            var response = ex switch
            {

                ValidationException validation => new AppException(
                    StatusCodes.Status400BadRequest,
                    "Validation error",
                    string.Join(",", validation.Errors.Select(x => x.ErrorMessage))),
                _ => new AppException(
                    StatusCodes.Status400BadRequest,
                    ex.Message,
                    ex.StackTrace!.ToString())
            };

            context.Response.StatusCode = response.StatusCode;
            context.Response.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(response);
            await context.Response.WriteAsync(json);
        }

    }
}