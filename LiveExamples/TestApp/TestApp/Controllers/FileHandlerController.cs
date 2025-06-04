using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestApp.DataLayer;
using TestApp.DTO;

namespace TestApp.Controllers
{
    public class FileHandlerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeDAL _employeeDAL;

        public FileHandlerController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _employeeDAL = new EmployeeDAL(_configuration);
        }
        public IActionResult GetFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
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


        public IActionResult GetFileFromDB(int id)
        {
            var contentType = "image/png";

            var employee = _employeeDAL.GetEmployee(id);

            if(string.IsNullOrEmpty(employee.IDImageFileName))
                return NotFound();

            var fileName = employee.IDImageFileName;

            var fileData = _employeeDAL.GetEmployee(id).IDImageAsByteArray;

            return File(fileData, contentType, fileName);
        }


    }
}
