using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using TestEFCore.Entity;
using TestEFCore.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestEfCore.Manager
{
    public class GenericUserManager : IUserManager
    {
        private IRepository<ESSPLUser> _userRepository { get; set; }
        private IRepository<Role> _roleRepository { get; set; }

        public GenericUserManager(IRepository<ESSPLUser> repository, IRepository<Role> roleRepository)
        {
            _userRepository = repository;
            _roleRepository = roleRepository;
        }

        public List<ESSPLUser> GetUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public ESSPLUser GetUserById(long userId)
        {
            return _userRepository.Get(u => u.UserID == userId);
        }

        public List<Role> GetRoles()
        {
            return _roleRepository.GetAll().ToList();
        }

        public void InsertUser(ESSPLUser user)
        {
            _userRepository.Insert(user);
        }

        public void UpdateUser(ESSPLUser updatedUser)
        {
            _userRepository.Update(updatedUser);
        }

        public void DeleteUser(long userId)
        {
            var userTobeDeleted = _userRepository.Get(u => u.UserID ==userId);  

            _userRepository.Delete(userTobeDeleted);
        }
    }
}
