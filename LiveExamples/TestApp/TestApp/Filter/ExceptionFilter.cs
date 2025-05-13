using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace TestApp
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Exception occurred: {context.Exception.Message}");
            context.Result = new ObjectResult("An error occurred, please try again later.")
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
