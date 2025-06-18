using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using EF_core.Data;    
using EF_core.Models;


public class UserController : Controller
{
    private readonly AppDbContext _context;
    public UserController(AppDbContext context) 
    {
        _context = context;
    }
    // GET: User
    public IActionResult Index()
    {
        var users = _context.User.ToList();
        return View(users);
    }

    // GET: User/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: User/Create
    [HttpPost]
    public IActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(user);
    }

    // GET: User/Edit/5
    public IActionResult Edit(int id)
    {
        var user = _context.User.Find(id);
        return View(user);
    }

    // POST: User/Edit/5
    [HttpPost]
    public IActionResult Edit(User user)
    {
        _context.User.Update(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // GET: User/Delete/5
    public IActionResult Delete(int id)
    {
        var user = _context.User.Find(id);
        return View(user);
    }

    // POST: User/Delete/5
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var user = _context.User.Find(id);
        _context.User.Remove(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // GET: User/Details/5
    public IActionResult Details(int id)
    {
        var user = _context.User.Find(id);
        return View(user);
    }
}
