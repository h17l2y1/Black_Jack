using BlackJack.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;

namespace BlackJack.Controllers
{
    public class BaseController : Controller
    {
        private Logger log = LogManager.GetCurrentClassLogger();

        public IActionResult Index()
        {
            return View();
        }

        // BadRequest
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
            if (!modelState.IsValid)
                context.Result = new ContentResult()
                {
                    Content = "Model not valid",
                    StatusCode = 400
                };
            base.OnActionExecuting(context);
        }

        // Exception
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = BadRequest("505 error");
                HandleException(filterContext.Exception);
            }
        }

        // Logger
        private void HandleException(Exception ex)
        {
            string error = null;
            if (ex is NotFoundException)
            {
                error = $"{ex.Source} | Not found | {ex.Message}";
                log.Error(error);
            }
        }

    }
}
