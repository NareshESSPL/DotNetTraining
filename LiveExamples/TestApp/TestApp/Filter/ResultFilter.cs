using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace TestApp
{
    public class CustomResultFilter : ResultFilterAttribute
    {
        private Stopwatch _stopwatch;
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();

            Debug.WriteLine("Before executing result.");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _stopwatch.Stop();
            var elapsedTime = _stopwatch.ElapsedMilliseconds;
            Debug.WriteLine($"Action result execution time: {elapsedTime} ms");
        }
    }

}
