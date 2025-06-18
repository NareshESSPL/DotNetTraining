using Microsoft.AspNetCore.Identity;

namespace InvoiceApp.Models
{
    public class User : IdentityUser
    {

        public string FullName { get; set; }


    }
}
