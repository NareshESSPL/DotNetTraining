using System.ComponentModel.DataAnnotations;

namespace EFCORE.Entity
{
  
        public class User
        {
        [Key]
         public long UserID { get; set; }
        [Required]
         public string UserName { get; set; }
        [Required]
         public string Password { get; set; }
        [Required]
         public bool IsActive { get; set; }


        }
    }

