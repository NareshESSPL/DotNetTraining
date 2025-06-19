using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ESSPL.DTO.IdentityManagement
{
    public class CustomUserIdentity: IIdentity
    {
        
        public UserProfileDTO UserProfile { get; }

        //Identity Properties
        public string Name { get; }
        public string AuthenticationType { get; }
        public bool IsAuthenticated { get; }

        public CustomUserIdentity(UserProfileDTO userProfile)
        {
            UserProfile = userProfile;
            Name = userProfile.UserName;
            AuthenticationType = "CustomAuth";
            IsAuthenticated = true;
        }
    }

    public class CustomPrincipal : ClaimsPrincipal
    {
        public CustomPrincipal(CustomUserIdentity identity) : base(identity) { }

        public override IIdentity Identity => base.Identity;
    }
}
