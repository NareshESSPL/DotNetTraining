using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESSPL.Entity
{
    public abstract class BaseEntity
    {
        [Required]
        public long ModifiedBy { get; set; }

        [Required]
        public DateTime ModifiedOn { get; set; }
    }
}
