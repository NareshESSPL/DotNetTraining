using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace TestApp
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine($"Executing: {context.ActionDescriptor.DisplayName}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine($"Executed: {context.ActionDescriptor.DisplayName}");
        }
    }

}
