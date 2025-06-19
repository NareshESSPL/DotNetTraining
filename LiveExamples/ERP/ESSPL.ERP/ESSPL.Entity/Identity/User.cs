using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//https://learn.microsoft.com/en-us/ef/core/modeling/relationships/mapping-attributes
namespace ESSPL.Entity.Identity
{
    [Table("User")]
    public class ESSPLUser : BaseEntity
    {
        [Key]
        public long UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailID { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public bool IsActive { get; set; }

        // Navigation property
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Device> Devices { get; set; }
    }

    public class Role : BaseEntity
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        public string RoleName { get; set; }

        // Navigation properties
        public ICollection<UserRole> UserRoles { get; set; }
    }

    public class UserRole : BaseEntity
    {
        [Key]
        public long UserRoleID { get; set; }

        [ForeignKey("FK_UserRole_User")]
        [Required]
        public long UserID { get; set; }

        [ForeignKey("FK_UserRole_FKRole")]
        [Required]
        public int RoleID { get; set; }

        // Navigation properties
        public ESSPLUser User { get; set; }
        public Role Role { get; set; }
    }

    public class Device : BaseEntity
    {
        [Key]
        public int DeviceID { get; set; }

        [ForeignKey("FK_Device_User")]
        [Required]
        public long UserID { get; set; }

        [Required]
        public string DeviceName { get; set; }

        // Navigation property
        public ESSPLUser User { get; set; }
    }
}
