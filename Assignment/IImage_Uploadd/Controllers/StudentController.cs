using IImage_Uploadd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IImage_Uploadd.Models;
using IImage_Uploadd.ViewModel;
namespace IImage_Uploadd.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public StudentController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {   List<Student> students=await context.Studentss.ToListAsync();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.ImagePath!=null)
                {
                    string fn=Guid.NewGuid().ToString()+"_"+model.ImagePath.FileName;
                    string folder = Path.Combine(webHostEnvironment.WebRootPath, "StudentImages");
                    string ImagePathh=Path.Combine(folder,fn);
                    await model.ImagePath.CopyToAsync(new FileStream(ImagePathh, FileMode.Create));
                    Student student = new Student()
                    {
                        Name = model.Name,
                        DOB = model.DOB,
                        Email = model.Email,
                        ImagePath = fn
                    };
                    await context.Studentss.AddAsync(student);
                    context.SaveChanges();
                    return RedirectToAction("Index");

                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Student st = context.Studentss.FirstOrDefault(item => item.Id == id);
                if (st != null)
                {
                    return View(st);
                }
                else
                {
                    TempData["message"] = "Record not Found :" + id;
                    return RedirectToAction("Index");
                }
            }
            TempData["message"] = "Record not Found :" + id;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Student s = context.Studentss.FirstOrDefault(item => item.Id == id);
                if (s != null)
                {
                    return View(s);
                }
                else
                {
                    TempData["message"] = "Unable to Find the Record:" + id;
                    return RedirectToAction("Index");
                }
            }
            TempData["message"] = "Please Pass Id to edit the Data";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                context.Studentss.Update(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = context.Studentss.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = context.Studentss.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                // Optional: delete the image file as well
                var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "StudentImages", student.ImagePath);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                context.Studentss.Remove(student);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
