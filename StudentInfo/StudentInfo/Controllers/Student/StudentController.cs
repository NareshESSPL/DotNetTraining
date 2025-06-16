using DataLayer;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.AspNetCore.Http;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.SignalR;

namespace StudentInfo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<StudentController> _logger;
        private readonly StudentDAL _studentDAL;
        private readonly Student st;
        private List<Student> _students;

        public StudentController(ILogger<StudentController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _studentDAL = new StudentDAL(_configuration);
        }


        public async Task<IActionResult> Index(string query)
        {
            
            var students = string.IsNullOrEmpty(query)
                ? await _studentDAL.GetAllStudents()
                : await _studentDAL.SearchStudentsAsync(query);

            ViewBag.Query = query;
            return View(students.AsEnumerable());
        }

        //[HttpPost]
        //public async Task<IActionResult> FilterAction(Student student)
        //{
        //    var students = await _studentDAL.GetAllStudents();
        //    ViewBag.FilterList = new MultiSelectList(FilterOptions(), "Value", "Text");

        //    if (student.FilterList != null && student.FilterList.Any())
        //    {
        //        foreach (var filter in student.FilterList)
        //        {
        //            switch (filter.Text)
        //            {
        //                case "StudentID":
        //                    students = students.OrderBy(s => s.StudentRegistrationId).ToList();
        //                    break;
        //                case "StudentName":
        //                    students = students.OrderByDescending(s => s.StudentName).ToList();
        //                    break;
        //                case "StudentAge":
        //                    students = students.OrderBy(s => s.StudentAge).ToList();
        //                    break;
        //            }
        //        }
        //    }

        //    return View("Index", students.AsEnumerable());
        //}



        public IActionResult Create(Student student)
        {
            ViewData["StudGen"] = GetGenderOptions();
            return View(student);
        }

        [HttpPost]
        public IActionResult SaveStudent(Student student)
        {
            ModelState.Remove(nameof(student.FileName));
            ModelState.Remove(nameof(student.EmployeeImage));
            ModelState.Remove(nameof(student.StudentRegistrationId));
            ModelState.Remove(nameof(student.IDImageAsByteArray));
            ModelState.Remove(nameof(student.IDImage));
            ModelState.Remove(nameof(student.IDFileName));

            if (ModelState.IsValid)
            {
                ViewData["StudGen"] = GetGenderOptions();

                if(student.EmployeeImage!=null && student.EmployeeImage.Length>0)
                {
                    var fileName= Guid.NewGuid().ToString();
                    var fileExtension = Path.GetExtension(student.EmployeeImage.FileName);
                    var fileFullName = $"{fileName}{fileExtension}";
                    /*Path.Combine(fileName,fileExtension)*/
                    

                    var filePath = Path.Combine("wwwroot/uploads/", fileFullName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        student.EmployeeImage.CopyTo(stream);
                    }
                    ViewBag.Message = "File uploaded successfully!";
                    student.FileName = fileFullName;
                    student.IDFileName = fileFullName; // Assuming you want to use the same file name for IDImage
                    // _studentDAL.AddImage(student.EmployeeImage);

                }
                else
                {
                    ViewBag.Message = "No file selected or error during upload.";
                    return View("Index");
                }
                _studentDAL.AddStudent(student);

                return RedirectToAction("Index");
            }
            
            return View("~/Views/Student/Create.cshtml", student);
        }

        public IActionResult Delete(int id)
        {
            _studentDAL.StudentDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var studentData = _studentDAL.GetStudent(id);

          

            ViewData["StudGen"] = GetGenderOptions();
            return View("Edit", studentData); // Use separate Edit view for better clarity
        }



        //[HttpGet]
        //public IActionResult ShowFile(string fileName)
        //{

        //    //if(string.IsNullOrEmpty(fileName))
        //    //{
        //    //    return NotFound();
        //    //}
        //    var filePath = Path.Combine("wwwroot/uploads/", fileName);
        //    //if (!System.IO.File.Exists(filePath))
        //    //{
        //    //    return NotFound();
        //    //}
        //    var provider = new FileExtensionContentTypeProvider();
        //    provider.TryGetContentType(fileName, out string contentType);
        //    contentType ??= "application/octet-stream";
        //    //var fileBytes = System.IO.File.ReadAllBytes(filePath);

        //    return PhysicalFile(filePath, contentType, fileName);
        //}
        [HttpGet]
        public FileResult Download(int id)
        {
            var student = _studentDAL.GetStudent(id);
            
            var filePath = Path.Combine("wwwroot/uploads/", student.IDFileName);
            

            // Adding the downloaded file to download's folder.
            using (var stream = new FileStream("wwwroot/downloads/"+ student.FileName + "", FileMode.Create, FileAccess.Write))
            {
                using (var memoryStream = new MemoryStream(student.EmployeeImageAsByteArray))
                {
                    
                    memoryStream.CopyTo(stream);
                    var fileBytesFile = memoryStream.ToArray();

                    // Return the file as a download
                    return File(fileBytesFile, "application/octet-stream", student.FileName);
                }
            }

            
        }

        private IEnumerable<SelectListItem> GetGenderOptions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem("Male", "1"),
                new SelectListItem("Female", "2"),
                new SelectListItem("Others", "3")
            }.AsEnumerable();
            
        }

        private List<SelectListItem> FilterOptions()
        {
            return new List<SelectListItem>{
               // new SelectListItem("All", "0"),
                new SelectListItem("StudentID","1"),
                new SelectListItem("StudentName","2"),
                new SelectListItem("StudentAge","3"),
            };
        }

       
    }
    // Fix for CS0117: 'Model' does not contain a definition for 'IsSuccess'
    // The error indicates that the 'Model' class does not have a property named 'IsSuccess'.
    // To resolve this, we need to ensure that the 'Model' class has the 'IsSuccess' property defined.

    
}
