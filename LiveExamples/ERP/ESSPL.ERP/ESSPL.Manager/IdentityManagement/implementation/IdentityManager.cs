using Microsoft.Extensions.Logging;
using ESSPL.DTO.IdentityManagement;
using System.Net.Http;
using System.Security.Claims;
using ESSPL.DTO;
using System;
using ESSPL.Repository;
using Microsoft.EntityFrameworkCore;
using ESSPL.Entity.Identity;


namespace ESSPL.Manager.IdentityManagement
{
    public class IdentityManager : IIdentityManager
    {
        private readonly ILogger<IdentityManager> _logger;
        private readonly ESSPLERPDbContext _eSSPLERPDbContext;

        public IdentityManager(ILogger<IdentityManager> logger, ESSPLERPDbContext eSSPLERPDbContext )
        {
            _logger = logger;
            _eSSPLERPDbContext = eSSPLERPDbContext;
        }

        public UserProfileDTO GetUserProfile(LoginRequestDTO loginRequestDto)
        {
            //var userProfile = new UserProfileDTO()
            //{
            //    UserID = 1,

            //    UserName = "NareshESSP",

            //    EmailID = "naresh@email.com",

            //    PhoneNumber = "986543210",

            //    FirstName = "Naresh",

            //    LastName = "Pradhan",

            //    LastLogin = DateTime.Now,

            //    IsEmailConfirmed = true,

            //    IsActive = true,

            //    IsPhoneConfirmed = true,

            //};

            var userProfile =
                _eSSPLERPDbContext.Users
                .Where(u => u.EmailID == loginRequestDto.UniqueId ||
                            u.PhoneNumber == loginRequestDto.UniqueId ||
                            u.UserName == loginRequestDto.UniqueId)
                .Select(u => 
                new UserProfileDTO()
                    {

                    UserID = u.UserID,
                    UserName = u.UserName,
                    EmailID = u.EmailID,
                    PhoneNumber = u.PhoneNumber,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }).FirstOrDefault();


            return userProfile;
        }

        public async Task<List<ESSPLUser>> GetAllUsers()
        {
            return await _eSSPLERPDbContext.Users.ToListAsync();
        }

        public async Task<ESSPLUser> GetUserById(long userId)
        {
            return await _eSSPLERPDbContext.Users.FirstOrDefaultAsync(u => u.UserID == userId);
        }

        public async Task<List<ESSPLUser>> GetActiveUsers()
        {
            return await _eSSPLERPDbContext.Users.Where(u => u.IsActive).ToListAsync();
        }

        //Update
        public async Task<List<ESSPLUser>> GetUsersWithoutTracking()
        {
            return await _eSSPLERPDbContext.Users.AsNoTracking().ToListAsync();
        }

        //Update Only Specific Properties
        public async Task UpdateUser(long userId, string newEmail, string newPhone)
        {
            var user = await _eSSPLERPDbContext.Users.FindAsync(userId);
            if (user != null)
            {
                user.EmailID = newEmail;
                user.PhoneNumber = newPhone;
                _eSSPLERPDbContext.Users.Update(user);
                await _eSSPLERPDbContext.SaveChangesAsync();
            }
        }

        //Bulk Update using LINQ
        public async Task ActivateUsers(List<long> userIds)
        {
            var users = await _eSSPLERPDbContext.Users.Where(u => userIds.Contains(u.UserID)).ToListAsync();

            foreach (var user in users)
            {
                user.IsActive = true;
            }

            await _eSSPLERPDbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(long userId)
        {
            var user = await _eSSPLERPDbContext.Users.FindAsync(userId);
            if (user != null)
            {
                _eSSPLERPDbContext.Users.Remove(user);
                await _eSSPLERPDbContext.SaveChangesAsync();
            }
        }

    }
}
