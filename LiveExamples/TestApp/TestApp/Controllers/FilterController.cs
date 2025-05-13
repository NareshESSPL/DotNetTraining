using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestApp.Controllers
{
    /*
    To add to all action methods in project use this in main method
    builder.Services.AddControllers(options =>
    {
        options.Filters.Add<LogActionFilter>();
    });

    builder.Services.AddControllers(options =>
    {
        options.Filters.Add<CustomResultFilter>();
    });

    builder.Services.AddControllers(options =>
    {
        options.Filters.Add<CustomExceptionFilter>();
    });
    note you can use global handler
    app.UseExceptionHandler("/Home/Error");


    */

    //controller level
    //apply to all action in the controller
    [LogActionFilter]
    [CustomResultFilter]
    [CustomExceptionFilter]
    //Filter
    public class FilterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    //Filter2/Index
    public class Filter2Controller : Controller
    {
        //action level
        [LogActionFilter]
        [CustomResultFilter]
        [CustomExceptionFilter]
        public IActionResult Index()
        {
            return View();
        }
    }
}
