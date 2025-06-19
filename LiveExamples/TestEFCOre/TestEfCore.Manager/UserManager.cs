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

        public List<ESSPLUser> GetUsers()
        {
            var users = _testEFCoreDbContext.User.ToList();

            return users;
        }
    }
}
