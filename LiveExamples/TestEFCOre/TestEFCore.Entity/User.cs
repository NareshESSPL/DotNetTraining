using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestEFCore.Entity
{
    public class User
    {
        //primery key column by convention
        public long UserID { get; set; }

        [Required] //Not null
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required] //Not null
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }

    public class Role
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; }

    }

    public class UserRole
    {
        public long UserRoleID { get; set; }

        public long UserID { get; set; }

        public int RoleID { get; set; }

    }

    public class Device
    {
        public int DeviceID { get; set; }
        public long UserID { get; set; }
        public string DeviceName { get; set; }
    }
}
