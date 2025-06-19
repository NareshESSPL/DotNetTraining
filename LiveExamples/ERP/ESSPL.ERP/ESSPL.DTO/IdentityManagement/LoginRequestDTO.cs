using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESSPL.DTO
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "Please provide UserName or PhoneNo or EmailID")]
        [Display(Name = "UserName or PhoneNo or EmailID")]
        public string UniqueId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
