using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using TestEFCore.Entity;
using TestEFCore.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestEfCore.Manager
{
    public class UserManager : IUserManager
    {
        private TestEFCoreDbContext _testEFCoreDbContext { get; set; }

        public UserManager(TestEFCoreDbContext testEFCoreDbContext)
        {
            _testEFCoreDbContext = testEFCoreDbContext;
        }

        public List<ESSPLUser> GetUsersWithSelect()
        {
            var users1 = _testEFCoreDbContext.User.Select(u => u);

            var users2 = from u in _testEFCoreDbContext.User
                         select u;

            var users3 = from u in _testEFCoreDbContext.User
                         join ur in _testEFCoreDbContext.UserRole on u.UserID equals ur.UserID
                         join r in _testEFCoreDbContext.Role on ur.RoleID equals r.RoleID 
                         select new 
                         { 
                             u.UserID,
                             r.RoleID,
                             u.UserName,
                             r.RoleName
                         };


            return users1.ToList();
        }

        public List<ESSPLUser> GetUsersAllLoadingScenario()
        {
            //lazy
            var users = _testEFCoreDbContext.User.ToList();

            foreach(var user1 in users)
            {
                //this will come null
                var role = user1.UserRoles;
            }

            var user = _testEFCoreDbContext.User.FirstOrDefault();


            //eager
            var userWithUserRole = _testEFCoreDbContext.User.Include(u => u.UserRoles).ToList();

            foreach (var user2 in users)
            {
                var role = user2.UserRoles;
            }

            return users;
        }

        public List<ESSPLUser> GetUserFromSql(long userId)
        {
            var users = _testEFCoreDbContext.User
                            .FromSqlRaw("EXEC GetUser @UserID = {0}", userId)
                            .ToList();

            return users;
        }

        public List<ESSPLUser> GetUsers()
        {
            //eager loading
            var users = _testEFCoreDbContext.User
                            .Include(u => u.UserRoles)
                                .ThenInclude(ur => ur.Role)
                                    .OrderByDescending(u => u.ModifiedOn).AsNoTracking();
                        

            return users.ToList();
        }

        public ESSPLUser GetUserById(long userId)
        {
            //eager loading
            var users = _testEFCoreDbContext.User.Where(i=> i.UserID == userId)
                            .Include(u => u.UserRoles)
                                .ThenInclude(ur => ur.Role)
                                    .OrderByDescending(u => u.ModifiedOn).AsNoTracking();


            return users.FirstOrDefault();
        }

        public List<Role> GetRoles()
        {
            var roles = _testEFCoreDbContext.Role.ToList();

            return roles;
        }

        public void InsertUser(ESSPLUser user)
        {
            //Setting data for shadow property
            //_testEFCoreDbContext.Entry(user).Property("ModifiedBy").CurrentValue = DateTime.UtcNow;

            _testEFCoreDbContext.Add(user);
            _testEFCoreDbContext.SaveChanges();
        }

        public void UpdateUser(ESSPLUser updatedUser)
        {
            //option1 Tracked
            //var existingUser = _testEFCoreDbContext.User.Where(i => i.UserID == updatedUser.UserID)
            //                .Include(u => u.UserRoles)
            //                    .ThenInclude(ur => ur.Role)
            //                        .OrderByDescending(u => u.ModifiedOn).FirstOrDefault();
            //existingUser = updatedUser;

            //_testEFCoreDbContext.Update(existingUser);

            //option 2 Untracked
            _testEFCoreDbContext.Attach(updatedUser);

            //This will run update for all property in DB table
            _testEFCoreDbContext.Entry(updatedUser).State = EntityState.Modified;

            //This will update only specific column
            _testEFCoreDbContext.Entry(updatedUser).Property(u => u.IsActive).IsModified = true;

            _testEFCoreDbContext.SaveChanges();
        }

        public void DeleteUser(long userID)
        {
            //option1 Tracked
            //var existingUser = _testEFCoreDbContext.User.Where(u => u.UserID == userID);
            //_testEFCoreDbContext.User.Remove(existingUser);
            //_testEFCoreDbContext.SaveChanges();

            //option 2 Untracked
            var user = new ESSPLUser { UserID = userID };
            _testEFCoreDbContext.Entry(user).State = EntityState.Deleted;
            _testEFCoreDbContext.SaveChanges();
        }

        public void TranExample()
        {
            using var transaction = _testEFCoreDbContext.Database.BeginTransaction();

            try
            {
                var role = new Role { RoleName = "TestRole1" };

                _testEFCoreDbContext.Add(role);
                _testEFCoreDbContext.SaveChanges();

                var user = new ESSPLUser
                {
                    UserName = "Naresh",

                    Password = "Test1233",

                    IsActive = true,

                    ModifiedOn = DateTime.UtcNow,
                };

                _testEFCoreDbContext.Add(user);
                _testEFCoreDbContext.SaveChanges();

                var userRole = new UserRole
                {
                    UserID = user.UserID,

                    RoleID = role.RoleID
                };

                _testEFCoreDbContext.Add(userRole);
                _testEFCoreDbContext.SaveChanges();


                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public void TestLinq()
        {
            //Join User with Device
            var query1 = from u in _testEFCoreDbContext.User
                        join d in _testEFCoreDbContext.Device on u.UserID equals d.UserID
                        select new { u.UserName, d.DeviceName };

            //2. Join User with Role via UserRole
            var query2 = from ur in _testEFCoreDbContext.UserRole
                        join u in _testEFCoreDbContext.User on ur.UserID equals u.UserID
                        join r in _testEFCoreDbContext.Role on ur.RoleID equals r.RoleID
                        select new { u.UserName, r.RoleName };

            //3. Group Devices by User
            var query3 = from d in _testEFCoreDbContext.Device
                        group d by d.UserID into g
                        select new { UserID = g.Key, DeviceCount = g.Count() };

            //4. Group Users by IsActive and Order by Count Descending
            var query4 = from u in _testEFCoreDbContext.User
                        group u by u.IsActive into g
                        orderby g.Count() descending
                        select new { IsActive = g.Key, Count = g.Count() };

            //5. Union Active and Inactive Users' UserNames
            var activeUsers = _testEFCoreDbContext.User.Where(u => u.IsActive).Select(u => u.UserName);
            var inactiveUsers = _testEFCoreDbContext.User.Where(u => !u.IsActive).Select(u => u.UserName);

            var query = activeUsers.Union(inactiveUsers);

            //6.Join with OrderBy by Modified Date
            var query5 = from u in _testEFCoreDbContext.User
                        join ur in _testEFCoreDbContext.UserRole on u.UserID equals ur.UserID
                        orderby u.ModifiedOn descending
                        select new { u.UserName, u.ModifiedOn };


            //7. List Users with Their Roles and Devices
            var query6 = from u in _testEFCoreDbContext.User
                        join ur in _testEFCoreDbContext.UserRole on u.UserID equals ur.UserID
                        join r in _testEFCoreDbContext.Role on ur.RoleID equals r.RoleID
                        join d in _testEFCoreDbContext.Device on u.UserID equals d.UserID
                        select new { u.UserName, Role = r.RoleName, d.DeviceName };


            //8.Left Outer Join of Users and Devices
            var query7 = from u in _testEFCoreDbContext.User
                        join d in _testEFCoreDbContext.Device on u.UserID equals d.UserID into userDevices
                        select new { u.UserName, DeviceCount = userDevices.Count() };

            //9. Get All Role Names Assigned to Any User
            var query8 = _testEFCoreDbContext.UserRole
                .Join(_testEFCoreDbContext.Role,
                      ur => ur.RoleID,
                      r => r.RoleID,
                      (ur, r) => r.RoleName)
                .Distinct();


            //10. Order Users by Number of Roles Assigned
            var query9 = from ur in _testEFCoreDbContext.UserRole
                        group ur by ur.UserID into g
                        orderby g.Count() descending
                        select new { UserID = g.Key, RoleCount = g.Count() };


        }
    }
}
