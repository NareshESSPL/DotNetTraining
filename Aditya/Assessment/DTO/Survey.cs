using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{   
    public class Survey
        {
            public int SurveyID { get; set; }
            public int SurveyTypeID { get; set; }
            public string SurveyName { get; set; } = string.Empty; 
            public string ModifiedBy { get; set; } = string.Empty;
            public DateTime ModifiedDate { get; set; }
        }
}
