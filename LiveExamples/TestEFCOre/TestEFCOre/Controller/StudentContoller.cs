using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using TestEfCore.Manager;
using TestEFCore.DTO;
using TestEFCore.Entity;
using TestEFCore.Repository;

namespace TestEFCore
{
    public class StudentContoller : Controller
    {
        //private readonly IStudentManager _studentManager;

        //public StudentContoller(IStudentManager studentManager)
        //{
        //    _studentManager = studentManager;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var users = _userManager.GetUsers();

        //    return View(users);
        //}

        //public IActionResult Create()
        //{
        //    ViewBag.Roles = new MultiSelectList(_userManager.GetRoles(), "RoleID", "RoleName");
            
        //    return View(new UserWithRoleDTO());
        //}

        //[HttpPost]
        //public IActionResult Create(UserWithRoleDTO userWithRoleDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ESSPLUser
        //        {
        //            UserID = userWithRoleDto.UserID,

        //            UserName = userWithRoleDto.UserName,

        //            Password = userWithRoleDto.Password,

        //            IsActive = userWithRoleDto.IsActive,

        //            ModifiedOn = DateTime.UtcNow
        //        };

        //        if (userWithRoleDto.SelectedRoleIDs.Count > 0)
        //        {
        //            var userRoles = new List<UserRole>();

        //            foreach (var roleId in userWithRoleDto.SelectedRoleIDs)
        //            {
        //                var userRole = new UserRole() { RoleID = roleId };

        //                userRoles.Add(userRole);
        //            }

        //            user.UserRoles = userRoles;

        //        }
        //        else
        //        {
        //            var role = new Role() { RoleName = userWithRoleDto.NewRoleName };

        //            var userRole = new UserRole() { Role = role };

        //            user.UserRoles = new UserRole[] { userRole };
        //        }

        //        if (user.UserID == 0)
        //        {
        //            _userManager.InsertUser(user);
        //        }
        //        else
        //        {
        //            _userManager.UpdateUser(user);
        //        }

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(new UserWithRoleDTO());
        //}

        //public IActionResult Edit(long id)
        //{
        //    ViewBag.Roles = new MultiSelectList(_userManager.GetRoles(), "RoleID", "RoleName");

        //    var user = _userManager.GetUserById(id);

        //    var userWithRoleDto = new UserWithRoleDTO()
        //    {
        //        UserID = user.UserID,

        //        UserName = user.UserName,

        //        Password = user.Password,

        //        IsActive = user.IsActive
        //    };

        //    foreach(var userRole in user.UserRoles)
        //    {
        //        userWithRoleDto.SelectedRoleIDs.Add(userRole.RoleID);
        //    }

        //    return View("Create", userWithRoleDto);
        //}

        //public IActionResult Delete(long id)
        //{
        //    _userManager.DeleteUser(id);

        //    ViewBag.Roles = new MultiSelectList(_userManager.GetRoles(), "RoleID", "RoleName");

        //    var users = _userManager.GetUsers();

        //    return View("Index", users);
        //}
    }
}
