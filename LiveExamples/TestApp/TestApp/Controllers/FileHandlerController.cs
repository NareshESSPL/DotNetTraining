using ClosedXML.Excel;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using PuppeteerSharp;
using System.Data;
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

            if (string.IsNullOrEmpty(employee.IDImageFileName))
                return NotFound();

            var fileName = employee.IDImageFileName;

            var fileData = _employeeDAL.GetEmployee(id).IDImageAsByteArray;

            return File(fileData, contentType, fileName);
        }

        /// <summary>
        /// export file using ClosedXML
        /// step 1 -- Open Nuget package manager console
        /// Step 2 -- run command Install-Package ClosedXML
        /// Step 3 -- Use below code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ExportToExcel()
        {
            //Option 1 itreating thrigh a collection
            using (var workbook = new XLWorkbook())
            {
                var dtEmployee = _employeeDAL.GetEmployeesAsTable();

                var worksheet = workbook.Worksheets.Add("Employee");
                foreach (DataColumn col in dtEmployee.Columns)
                {
                    worksheet.Cell(1, 1).Value = col.ColumnName;
                }

                var rowNum = 2;
                foreach (DataRow row in dtEmployee.Rows)
                {
                    worksheet.Cell(rowNum, 1).Value = row[0].ToString();
                    worksheet.Cell(rowNum, 2).Value = row[1].ToString();
                    worksheet.Cell(rowNum, 3).Value = row[2].ToString();
                    rowNum++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employee.xlsx");
                }
            }

            //Option2 using DataTable directly
            //using (var workbook = new XLWorkbook())
            //{
            //    var dtEmployee = _employeeDAL.GetEmployeesAsTable();

            //    var worksheet = workbook.Worksheets.Add(dt, "Sheet1");

            //    using (var stream = new MemoryStream())
            //    {
            //        workbook.SaveAs(stream);
            //        var content = stream.ToArray();
            //        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SampleData.xlsx");
            //    }
            //}
        }


        /// <summary>
        /// Step 1 --> Open nuget package console
        /// Step 2 --> run the command "Install-Package ExcelDataReader"
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ImportExcel(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string filePath = Path.Combine("wwwroot/uploads", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                DataTable dt = ReadExcel(filePath);
                _employeeDAL.BulkInsert(dt);
            }

            return RedirectToAction("Index", "Employee");
        }

        /// <summary>
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public DataTable ReadExcel(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var dt = new DataTable();

            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var count = 0;

                    dt.Columns.Add("Name", typeof(string));
                    dt.Columns.Add("Age", typeof(int));
                    dt.Columns.Add("Gender", typeof(int));

                    while (reader.Read())
                    {
                        //skip the first row as it a header row
                        if (count == 0)
                        {
                            count++;
                            continue;
                        }

                        var name = reader.GetString(0);
                        var age = reader.GetDouble(1);
                        var gender = reader.GetString(2).ToLower() == "female" ? 2 : 1;

                        dt.Rows.Add(name, age, gender);

                        count++;
                    }
                }
            }

            return dt;
        }

        /// <summary>
        /// Step 1 --> Open Nuget Package manager console
        /// Step 2 --> Run the command "Install-Package PuppeteerSharp"
        /// </summary>
        /// <param name="htmlContent"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("text/plain")]
        public IActionResult ExportToPdf(string html)
        {
            using var reader = new StreamReader(HttpContext.Request.Body);
            string bodyContent = reader.ReadToEndAsync().Result;

            var pdfBytes = ConvertHtmlToPdf(bodyContent).Result;
            return File(pdfBytes, "application/pdf", "document.pdf");
        }

        public async Task<byte[]> ConvertHtmlToPdf(string htmlContent)
        {
            await new BrowserFetcher().DownloadAsync();

            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            using var page = await browser.NewPageAsync();

            await page.SetContentAsync(htmlContent);
            return await page.PdfDataAsync();
        }
    }
}
