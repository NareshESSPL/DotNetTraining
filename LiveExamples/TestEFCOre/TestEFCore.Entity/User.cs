using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System;

namespace TestEFCore.Entity
{
    public class BaseEntity 
    {
        [Required]
        public DateTime ModifiedOn { get; set; }
    }


    [Table("User")]

    [Index(nameof(UserName), nameof(UserID), Name = "IX_User_Username_UserID", AllDescending = true)]
    public class ESSPLUser : BaseEntity
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

        
        public virtual IEnumerable<Device> Devices { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }

    public class Role: BaseEntity
    {
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }

    public class UserRole : BaseEntity
    {
        public long UserRoleID { get; set; }

        public long UserID { get; set; }

        public int RoleID { get; set; }

        public virtual ESSPLUser User { get; set; }

        public virtual Role Role { get; set; }

    }

    public class Device : BaseEntity
    {
        [Key]
        public int DeviceID { get; set; }

        public long UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DeviceName { get; set; }

        public virtual ESSPLUser User { get; set; }
    }
    
    //Self referencing
    public class Employee : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public int? ManagerId { get; set; } 
        public Employee Manager { get; set; }  // Navigation to manager
        public ICollection<Employee> Reportees { get; set; } = new List<Employee>();  // Navigation to subordinates
    }

}
