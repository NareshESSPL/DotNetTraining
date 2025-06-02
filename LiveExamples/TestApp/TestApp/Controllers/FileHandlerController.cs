using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestApp.DTO;

namespace TestApp.Controllers
{
    public class FileHandlerController : Controller
    {
        public IActionResult GetFile(string fileName)
        {
            if(string.IsNullOrEmpty(fileName))
            {
                return NotFound();
            }

            var filePath = Path.Combine(
                                        @"D:\ESSPL\.Net\SampleApplication\DotNetTraining\LiveExamples\TestApp\TestApp",
                                        "wwwroot", 
                                        "uploads", 
                                        fileName); // Adjust folder path
            
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var contentType = "image/png"; // Default MIME type
            
            return PhysicalFile(filePath, contentType, fileName);
        }


    }
}
