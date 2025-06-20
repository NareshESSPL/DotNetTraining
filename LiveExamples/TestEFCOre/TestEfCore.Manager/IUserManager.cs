using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEFCore.Entity;

namespace TestEfCore.Manager
{
    public interface IUserManager
    {
        public List<ESSPLUser> GetUsers();

        public ESSPLUser GetUserById(long userId);

        public List<Role> GetRoles();

        public void InsertUser(ESSPLUser user);

        public void UpdateUser(ESSPLUser updatedUser);

        public void DeleteUser(long userID);
    }
}
