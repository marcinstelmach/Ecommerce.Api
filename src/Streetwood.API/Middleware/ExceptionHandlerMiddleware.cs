using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate nextDelegate;
        private readonly ILogger logger;
        private readonly IQueueManager queueManager;
        private readonly IHostingEnvironment environment;

        public ExceptionHandlerMiddleware(RequestDelegate nextDelegate, ILogger<ExceptionHandlerMiddleware> logger, IQueueManager queueManager,
            IHostingEnvironment environment)
        {
            this.nextDelegate = nextDelegate;
            this.logger = logger;
            this.queueManager = queueManager;
            this.environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await nextDelegate(context);
            }
            catch (StreetwoodException exception)
            {
                var message = PrepareExceptionMessage(exception);
                
                if (exception.ErrorCode.StatusCode == HttpStatusCode.InternalServerError)
                {
                    if (!environment.IsDevelopment())
                    {
                        await queueManager.AddMessageAsync(message);
                    }

                    logger.LogError($"Streetwood exception with code '{exception.ErrorCode.ToString()}.\n{message}");
                }
                else
                {
                    logger.LogWarning($"Streetwood exception with code '{exception.ErrorCode.ToString()}.\n{message}");
                }

                await HandleException(context, exception);
            }
            catch (Exception exception)
            {
                var message = PrepareExceptionMessage(exception);
                logger.LogError(exception, message);
                if (!environment.IsDevelopment())
                {
                    await queueManager.AddMessageAsync(message);
                }

                await HandleException(context, exception);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var errorCodeName = nameof(HttpStatusCode.InternalServerError);
            var message = PrepareExceptionMessage(exception);

            if (exception is UnauthorizedAccessException)
            {
                errorCodeName = nameof(HttpStatusCode.Unauthorized);
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (exception is StreetwoodException streetwoodException)
            {
                statusCode = streetwoodException.ErrorCode.StatusCode;
                errorCodeName = streetwoodException.ErrorCode.ErrorCodeName;
                message = string.IsNullOrEmpty(message) ? streetwoodException.ErrorCode.Message : message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var responseBody = JsonConvert.SerializeObject(new { errorCodeName, message });

            return context.Response.WriteAsync(responseBody);
        }

        private string PrepareExceptionMessage(Exception exception)
        {
            var message = exception.Message;
            var stackTrace = exception.StackTrace;
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                message += $" --- Inner exception: {exception.Message}";
            }

            return $"{message}. ENVIRONMENT: '{environment.EnvironmentName}'. --- Stack trace: {stackTrace}.";
        }
    }
}