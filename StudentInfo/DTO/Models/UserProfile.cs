using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DTO.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Display(Name="Name")]
        [Required]
        public string UserName { get; set; } = "";

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; } = "";

       

        public int IsActive { get; set; }
    }
}
