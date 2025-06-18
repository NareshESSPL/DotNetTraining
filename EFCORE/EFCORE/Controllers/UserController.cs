using Data;
using EFCORE.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;



public class UserController : Controller
{
    private readonly AppDBContext _context;

    public UserController(AppDBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var users = _context.User.ToList();
        return View(users);
    }
}

   
   