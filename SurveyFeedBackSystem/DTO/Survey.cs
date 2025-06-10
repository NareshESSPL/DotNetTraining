using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Survey
    {

        public int SurveyId { get; set; }

        public int SurveyTypeId { get; set; }

        public string SurveyTypeName { get; set; }

        public string ModifiedBy { get; set; }

        public string ModifiedDate { get; set; }


    }
}
