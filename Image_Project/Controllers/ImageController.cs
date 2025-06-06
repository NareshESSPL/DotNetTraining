using Image_Project.Models;
using Image_Project.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace Image_Project.Controllers
{
    public class ImageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file, string name)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("File", "Please upload a file.");
                return View();
            }

            var allowedExtensions = new[] { ".jpg", ".png" };
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("File", "Only JPG and PNG files are allowed.");
                return View();
            }

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var image = new ImageUpload
            {
                Name = name,
                ImageData = ms.ToArray()
            };

            _context.ImageUploads.Add(image);
            await _context.SaveChangesAsync();

            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            var data = _context.ImageUploads.ToList();
            return View(data);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
