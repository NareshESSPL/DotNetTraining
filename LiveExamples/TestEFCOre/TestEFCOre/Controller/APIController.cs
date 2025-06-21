using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using TestEFCore.Entity;
using TestEFCore.Repository;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly TestEFCoreDbContext _context;

    public UsersController(TestEFCoreDbContext context)
    {
        _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public string GetUsers()
    {
        //var user = _context.User
        //    .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
        //    .Include(u => u.Devices).ToList();

        var result = from u in _context.User
                     join ur in _context.UserRole on u.UserID equals ur.UserID
                     join r in _context.Role on ur.RoleID equals r.RoleID
                     select new
                     {
                         u.UserID,
                         r.RoleID,
                         u.UserName,
                         r.RoleName
                     };

        var resultOrderBy = from u in _context.User
                            join ur in _context.UserRole on u.UserID equals ur.UserID
                            join r in _context.Role on ur.RoleID equals r.RoleID
                            orderby r.RoleID descending, u.UserID ascending
                            select new
                            {
                                u.UserID,
                                r.RoleID,
                                u.UserName,
                                r.RoleName
                            };

        var resultGroupBy = from u in _context.User
                            join ur in _context.UserRole on u.UserID equals ur.UserID
                            join r in _context.Role on ur.RoleID equals r.RoleID
                            group r by r.RoleID into g
                            select new
                            {
                               roleid = g.Key,
                               usercount = g.Count()
                            };


        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        // Serialize your data
        string json = JsonSerializer.Serialize(resultGroupBy, options);

        return json;
    }
}