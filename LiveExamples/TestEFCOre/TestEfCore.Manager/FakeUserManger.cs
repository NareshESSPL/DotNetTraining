using TestEFCore.Entity;
using TestEFCore.Repository;

namespace TestEfCore.Manager
{
    public class FakeUserManager : IUserManager
    {
        private TestEFCoreDbContext _testEFCoreDbContext { get; set; }

        public FakeUserManager(TestEFCoreDbContext testEFCoreDbContext)
        {
            _testEFCoreDbContext = testEFCoreDbContext;
        }

        public List<User> GetUsers()
        {
            return new List<User> 
            { 
                new User{UserName = "Naresh" },
                new User{UserName = "Suresh"}
            };
        }
    }
}
