using Microsoft.EntityFrameworkCore;
using System;
using TestEFCore.Entity;
using TestEFCore.Repository;

namespace TestEfCore.Manager
{
    public class UserManager : IUserManager
    {
        private TestEFCoreDbContext _testEFCoreDbContext { get; set; }

        public UserManager(TestEFCoreDbContext testEFCoreDbContext)
        {
            _testEFCoreDbContext = testEFCoreDbContext;
        }

        //public List<ESSPLUser> GetUsers()
        //{
        //    var users = _testEFCoreDbContext.User.Select(u => new { u.UserName });

        //    return users;
        //}

        public List<ESSPLUser> GetUsers()
        {
            //lazy
            var users = _testEFCoreDbContext.User.ToList();

            foreach(var user1 in users)
            {
                //this will come null
                var role = user1.UserRoles;
            }

            var user = _testEFCoreDbContext.User.FirstOrDefault();

            //explicit
            _testEFCoreDbContext.Entry(user).Collection(u => u.UserRoles).Load();

            var userRoles = user.UserRoles;


            //eager
            var userWithUserRole = _testEFCoreDbContext.User.Include(u => u.UserRoles).ToList();

            foreach (var user2 in users)
            {
                var role = user2.UserRoles;
            }

            return users;
        }
    }
}
