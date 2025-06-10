using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    //SurveyID, SurveyTypeID, SurveyTypeName, ModifiedBy, ModifiedDate.
     public abstract class SurveyBase
    {
        public int SurveyID { get; set; }

        public int SurveyTypeID { get; set; }

        [Required(ErrorMessage ="Field is Empty ,  can't submmit")]
        public string SurveyTypeName { get; set; }

        public string ModifiedBy { get; set; }

        public string ModifiedDate { get; set; }

    }

   
}
