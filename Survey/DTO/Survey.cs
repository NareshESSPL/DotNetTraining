using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class Survey
    {
       
        [Key]
        public int SurveyID { get; set; }
        public int SurveyTypeID { get; set; }
        [Required]
        public string SurveyTypeName { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
