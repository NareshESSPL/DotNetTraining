using ESSPL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ESSPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestAppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(TestAppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            // var helps = _appDbContext.Helps.ToListAsync();
            return View();

        }

        // List all Helps
        public async Task<IActionResult> List()
        {
            var helps = await _appDbContext.Helps.ToListAsync();
            return View(helps);
        }

        // Show details of one Help
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var help = await _appDbContext.Helps.FirstOrDefaultAsync(h => h.Id == id);
            if (help == null) return NotFound();

            return View(help);
        }

        // GET: Create form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create new Help with file upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Help help)
        {
            if (ModelState.IsValid)

            {
                {
                    Console.WriteLine("❌ ModelState is invalid");
                    return View(help);
                }

                Console.WriteLine("✅ ModelState is valid");

                if (help.Document != null && help.Document.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(help.Document.FileName);
                    var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                    if (!Directory.Exists(uploads))
                        Directory.CreateDirectory(uploads);

                    var filePath = Path.Combine(uploads, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await help.Document.CopyToAsync(stream);
                    }

                    help.DocumentPath = fileName;
                }

                _appDbContext.Helps.Add(help);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(help);
        }

        // GET: Edit form
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var help = await _appDbContext.Helps.FindAsync(id);
            if (help == null) return NotFound();

            return View(help);
        }

        // POST: Edit Help + replace file if uploaded
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Help help)
        {
            if (id != help.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existing = await _appDbContext.Helps.FindAsync(id);
                    if (existing == null) return NotFound();

                    existing.Name = help.Name;
                    existing.Department = help.Department;

                    if (help.Document != null && help.Document.Length > 0)
                    {
                        // Delete old file if exists
                        if (!string.IsNullOrEmpty(existing.DocumentPath))
                        {
                            var oldFile = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", existing.DocumentPath);
                            if (System.IO.File.Exists(oldFile))
                                System.IO.File.Delete(oldFile);
                        }

                        // Save new file
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(help.Document.FileName);
                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

                        if (!Directory.Exists(uploads))
                            Directory.CreateDirectory(uploads);

                        var filePath = Path.Combine(uploads, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await help.Document.CopyToAsync(stream);
                        }

                        existing.DocumentPath = fileName;
                    }

                    await _appDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_appDbContext.Helps.Any(e => e.Id == help.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(List));
            }
            return View(help);
        }

        // GET: Confirm delete page
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var help = await _appDbContext.Helps.FirstOrDefaultAsync(h => h.Id == id);
            if (help == null) return NotFound();

            return View(help);
        }

        // POST: Delete confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var help = await _appDbContext.Helps.FindAsync(id);
            if (help != null)
            {
                // Delete file if any
                if (!string.IsNullOrEmpty(help.DocumentPath))
                {
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", help.DocumentPath);
                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);
                }

                _appDbContext.Helps.Remove(help);
                await _appDbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(List));
        }
    }
}




//using ESSPL.Models;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Logging; // Added for more robust logging/debugging

//namespace ESSPL.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly TestAppDbContext _appDbContext;
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        private readonly ILogger<HomeController> _logger; // Added logger for detailed output

//        public HomeController(TestAppDbContext appDbContext, IWebHostEnvironment webHostEnvironment, ILogger<HomeController> logger)
//        {
//            _appDbContext = appDbContext;
//            _webHostEnvironment = webHostEnvironment;
//            _logger = logger; // Initialize logger
//        }

//        public IActionResult Index()
//        {
//            // This is your Home Page, showing a welcome message and a link
//            return View();
//        }

//        // List all Helps
//        public async Task<IActionResult> List()
//        {
//            var helps = await _appDbContext.Helps.ToListAsync();
//            return View(helps);
//        }

//        // Show details of one Help
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null) return NotFound();

//            var help = await _appDbContext.Helps.FirstOrDefaultAsync(h => h.Id == id);
//            if (help == null) return NotFound();

//            return View(help);
//        }

//        // GET: Create form
//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Create new Help with file upload
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Help help)
//        {
//            // IMPORTANT: Log ModelState errors to Visual Studio's Output window for debugging
//            if (!ModelState.IsValid)
//            {
//                _logger.LogWarning("ModelState is invalid. Errors detected:");
//                foreach (var modelStateEntry in ModelState.Values)
//                {
//                    foreach (var error in modelStateEntry.Errors)
//                    {
//                        if (!string.IsNullOrEmpty(error.ErrorMessage))
//                        {
//                            _logger.LogError($"Model Error: {error.ErrorMessage}");
//                        }
//                        else if (error.Exception != null)
//                        {
//                            _logger.LogError(error.Exception, "Model Error Exception:");
//                        }
//                    }
//                }
//            }

//            if (ModelState.IsValid)
//            {
//                // File upload logic only if Document is provided (and valid based on [Required])
//                if (help.Document != null && help.Document.Length > 0)
//                {
//                    try
//                    {
//                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(help.Document.FileName);
//                        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

//                        // Ensure the uploads directory exists
//                        if (!Directory.Exists(uploadsFolder))
//                        {
//                            Directory.CreateDirectory(uploadsFolder);
//                            _logger.LogInformation($"Created 'uploads' directory at: {uploadsFolder}");
//                        }

//                        var filePath = Path.Combine(uploadsFolder, fileName);

//                        using (var stream = new FileStream(filePath, FileMode.Create))
//                        {
//                            await help.Document.CopyToAsync(stream);
//                        }

//                        help.DocumentPath = fileName; // Store the file name in the model property
//                        _logger.LogInformation($"File uploaded successfully to: {filePath}");
//                    }
//                    catch (Exception ex)
//                    {
//                        _logger.LogError(ex, "Error uploading document to server.");
//                        ModelState.AddModelError("", "Error uploading document: " + ex.Message); // Add a general error to model state
//                        return View(help); // Return view with error if file upload fails
//                    }
//                }
//                else
//                {
//                    // This block should ideally not be hit if [Required] is on Document and client-side validation works,
//                    // or if server-side validation correctly sets ModelState.IsValid to false.
//                    _logger.LogWarning("Document was not provided or was empty, but ModelState was somehow valid. (This case should be rare with [Required]).");
//                }

//                try
//                {
//                    _appDbContext.Helps.Add(help);
//                    await _appDbContext.SaveChangesAsync();
//                    _logger.LogInformation("Help entry added to database successfully.");
//                    return RedirectToAction(nameof(List));
//                }
//                catch (DbUpdateException dbEx)
//                {
//                    // Catch database-specific exceptions
//                    _logger.LogError(dbEx, "Database error adding help entry.");
//                    ModelState.AddModelError("", "Database error: " + dbEx.InnerException?.Message ?? dbEx.Message);
//                }
//                catch (Exception ex)
//                {
//                    // Catch any other unexpected exceptions during saving
//                    _logger.LogError(ex, "An unexpected error occurred while saving help entry.");
//                    ModelState.AddModelError("", "An unexpected error occurred: " + ex.Message);
//                }
//            }
//            else
//            {
//                _logger.LogWarning("Model state is invalid. Redisplaying form with validation errors.");
//            }
//            return View(help); // Return the view with model and errors for display
//        }

//        // GET: Edit form
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null) return NotFound();

//            var help = await _appDbContext.Helps.FindAsync(id);
//            if (help == null) return NotFound();

//            return View(help);
//        }

//        // POST: Edit Help + replace file if uploaded
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, Help help)
//        {
//            if (id != help.Id) return NotFound();

//            // Log ModelState errors for debugging during edit
//            if (!ModelState.IsValid)
//            {
//                _logger.LogWarning("ModelState is invalid during Edit. Errors detected:");
//                foreach (var modelStateEntry in ModelState.Values)
//                {
//                    foreach (var error in modelStateEntry.Errors)
//                    {
//                        _logger.LogError($"Model Error (Edit): {error.ErrorMessage}");
//                    }
//                }
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    var existing = await _appDbContext.Helps.FindAsync(id);
//                    if (existing == null) return NotFound();

//                    existing.Name = help.Name;
//                    existing.Department = help.Department;

//                    // Handle file replacement if a new document is uploaded
//                    if (help.Document != null && help.Document.Length > 0)
//                    {
//                        // Delete old file if exists
//                        if (!string.IsNullOrEmpty(existing.DocumentPath))
//                        {
//                            var oldFile = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", existing.DocumentPath);
//                            if (System.IO.File.Exists(oldFile))
//                            {
//                                System.IO.File.Delete(oldFile);
//                                _logger.LogInformation($"Deleted old file: {oldFile}");
//                            }
//                        }

//                        // Save new file
//                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(help.Document.FileName);
//                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

//                        if (!Directory.Exists(uploads))
//                        {
//                            Directory.CreateDirectory(uploads);
//                        }

//                        var filePath = Path.Combine(uploads, fileName);

//                        using (var stream = new FileStream(filePath, FileMode.Create))
//                        {
//                            await help.Document.CopyToAsync(stream);
//                        }

//                        existing.DocumentPath = fileName;
//                        _logger.LogInformation($"New file uploaded for edit: {filePath}");
//                    }
//                    // Else, if no new document is uploaded, existing.DocumentPath remains unchanged.
//                    // If [Required] is on IFormFile Document, and it's an edit, you might need to handle this differently
//                    // if the user *removes* the file during edit. For simple edits, if Document is null, it just keeps the old path.

//                    _appDbContext.Helps.Update(existing); // Mark the entity as modified
//                    await _appDbContext.SaveChangesAsync();
//                    _logger.LogInformation("Help entry updated successfully.");
//                }
//                catch (DbUpdateConcurrencyException dbConcEx)
//                {
//                    // Handle concurrency conflicts if multiple users try to update the same record
//                    if (!_appDbContext.Helps.Any(e => e.Id == help.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        _logger.LogError(dbConcEx, "Concurrency error during update.");
//                        throw; // Re-throw to see the full exception in development
//                    }
//                }
//                catch (Exception ex)
//                {
//                    _logger.LogError(ex, "Error updating help entry.");
//                    ModelState.AddModelError("", "Error updating help entry: " + ex.Message);
//                    return View(help); // Stay on edit view if error
//                }
//                return RedirectToAction(nameof(List));
//            }
//            // If ModelState is invalid, return the view with errors
//            _logger.LogWarning("Model state is invalid during Edit. Redisplaying form.");
//            return View(help);
//        }

//        // GET: Confirm delete page
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null) return NotFound();

//            var help = await _appDbContext.Helps.FirstOrDefaultAsync(h => h.Id == id);
//            if (help == null) return NotFound();

//            return View(help);
//        }

//        // POST: Delete confirmed
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var help = await _appDbContext.Helps.FindAsync(id);
//            if (help != null)
//            {
//                // Delete file if any
//                if (!string.IsNullOrEmpty(help.DocumentPath))
//                {
//                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", help.DocumentPath);
//                    if (System.IO.File.Exists(filePath))
//                    {
//                        System.IO.File.Delete(filePath);
//                        _logger.LogInformation($"Deleted file during delete operation: {filePath}");
//                    }
//                }

//                _appDbContext.Helps.Remove(help);
//                await _appDbContext.SaveChangesAsync();
//                _logger.LogInformation($"Help entry with ID {id} deleted successfully.");
//            }
//            else
//            {
//                _logger.LogWarning($"Attempted to delete Help entry with ID {id} but it was not found.");
//            }
//            return RedirectToAction(nameof(List));
//        }
//    }
//}
