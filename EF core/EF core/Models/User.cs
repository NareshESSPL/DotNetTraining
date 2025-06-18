using System.ComponentModel.DataAnnotations.Schema;

namespace EF_core.Models
{
    [Table("User")]
    public class User
    {
        [Column("UserId")]
        public long Id { get; set; }


        [Column("UserName")]
        public string Name { get; set; }

        //[Column("MailId")]
        //public string Email { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
