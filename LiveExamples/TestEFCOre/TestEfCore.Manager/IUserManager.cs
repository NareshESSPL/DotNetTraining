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
        public List<User> GetUsers();
    }
}
