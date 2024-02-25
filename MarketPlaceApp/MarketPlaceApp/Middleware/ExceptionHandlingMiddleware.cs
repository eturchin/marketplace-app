using System.Net;
using System.Text.Json;
using DataPOC.Application.Dto.Error;

namespace DataPOC.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.InternalServerError,
                "Internal server error");
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, string exMessage, HttpStatusCode httpStatusCode,
        string message)
    {
        _logger.LogError(exMessage);

        var response = httpContext.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)httpStatusCode;

        var errorDto = new ErrorDto
        {
            Message = message,
            StatusCode = (int)httpStatusCode
        };

        var result = JsonSerializer.Serialize(errorDto);
        await response.WriteAsJsonAsync(result);
    }
}