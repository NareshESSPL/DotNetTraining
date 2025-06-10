using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositry
{
    public abstract class SurveyBase
    {

        public int SurveyId { get; set; }
        public int SurveyTypeId {  get; set; }

        public string SurveyName { get; set; }


        public string ModifiedBy { get; set; }

        public string ModifiedDate { get; set; }


 
    }
}
