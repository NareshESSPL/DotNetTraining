using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ESSPL.DTO
{
    public class UserProfileDTO
    {
        public long UserID { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailID { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime LastLogin { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public bool IsPhoneConfirmed { get; set;}

        public bool IsActive { get; set;}
    }
}
