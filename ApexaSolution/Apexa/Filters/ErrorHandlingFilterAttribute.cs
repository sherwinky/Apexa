using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Apexa.Filters
{
    /// <summary>
    /// Global error handler, handel the error in the site level
    /// </summary>
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ErrorHandlingFilterAttribute> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const int ServerSideErrorCode = 500;

        /// <summary>
        /// construction
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="webHostEnvironment">host environment</param>
        public ErrorHandlingFilterAttribute(ILogger<ErrorHandlingFilterAttribute> logger,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Exception
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            // log the error
            _logger.LogError(new EventId(0), context.Exception, context.Exception.ToString());

            // exception is handled
            context.ExceptionHandled = true;

            context.HttpContext.Response.StatusCode = 500;
            context.Result = new JsonResult(new
            {
                Code = ServerSideErrorCode,
                Status = "INTERNAL_SERVER_ERROR",
                Message = context.Exception.GetBaseException().Message,
                Details = _webHostEnvironment.IsDevelopment()
                    ? new List<string>() { context.Exception.StackTrace }
                    : null
            });
        }
    }
}
