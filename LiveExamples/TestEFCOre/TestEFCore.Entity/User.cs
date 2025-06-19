using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestEFCore.Entity
{
    [Table("User")]
    public class ESSPLUser
    {
        //primery key column by convention
        [Key]
        public long UserID { get; set; }

        [Required] //Not null
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required] //Not null
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public DateTime ModifiedOn { get; set; }

        public virtual IEnumerable<Device> Devices { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }

    public class Role
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }

    }

    public class UserRole
    {
        public long UserRoleID { get; set; }

        public long UserID { get; set; }

        public int RoleID { get; set; }

        public virtual ESSPLUser User { get; set; }

        public virtual Role Role { get; set; }

    }

    public class Device
    {
        [Key]
        public int DeviceID { get; set; }

        public long UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DeviceName { get; set; }

        public virtual ESSPLUser User { get; set; }
    }
}
