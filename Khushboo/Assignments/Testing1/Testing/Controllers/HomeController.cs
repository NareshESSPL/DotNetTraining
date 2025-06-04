using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestAppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, TestAppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: / or /Home/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/List
        public IActionResult List()
        {
            List<Student> students = _appDbContext.Students.ToList();
            return View(students);
        }

        // GET: /Home/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Home/Create
        [HttpPost]
       
        public async Task<IActionResult> Create(Student student, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    var filePath = Path.Combine(uploads, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    student.FileName = fileName;
                }

                _appDbContext.Students.Add(student);
                _appDbContext.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        // GET: /Home/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");

            var student = _appDbContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return RedirectToAction("List");

            return View(student);
        }

        // POST: /Home/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null && file.Length > 0)
                    {
                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                        if (!Directory.Exists(uploads))
                            Directory.CreateDirectory(uploads);

                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var filePath = Path.Combine(uploads, fileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }

                        // Delete old file if exists
                        if (!string.IsNullOrEmpty(student.FileName))
                        {
                            var oldFile = Path.Combine(uploads, student.FileName);
                            if (System.IO.File.Exists(oldFile))
                            {
                                System.IO.File.Delete(oldFile);
                            }
                        }

                        student.FileName = fileName;
                    }

                    _appDbContext.Students.Update(student);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                }
            }
            return RedirectToAction("List");
        }

        // GET: /Home/Delete/{id}
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("List");

            var student = _appDbContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return RedirectToAction("List");

            return View(student);
        }

        // POST: /Home/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _appDbContext.Students.FindAsync(id);
            if (student != null)
            {
                // Delete associated file if exists
                if (!string.IsNullOrEmpty(student.FileName))
                {
                    var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, student.FileName);

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _appDbContext.Students.Remove(student);
                await _appDbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }

        // GET: /Home/Details/{id}
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("List");

            var student = _appDbContext.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return RedirectToAction("List");

            return View(student);
        }

        // GET: /Home/DownloadFile?fileName=filename.ext
        public IActionResult DownloadFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return NotFound();

            var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var contentType = "application/octet-stream"; // Generic content type, can be improved using a mime map
            return PhysicalFile(filePath, contentType, fileName);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
