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

        public List<ESSPLUser> GetUsers()
        {
            return new List<ESSPLUser> 
            { 
                new ESSPLUser{UserName = "Naresh" },
                new ESSPLUser{UserName = "Suresh"}
            };
        }
    }
}
