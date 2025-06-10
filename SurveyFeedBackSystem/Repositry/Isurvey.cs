using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Repositry
{
    public interface Isurvey
    {
        public List<Survey> GetAllSurveyDetails();
        public void AddSurvey(Survey survey);

        public void UpdateSurvey(Survey survey);
        public void DeleteSurvey(int id);


    }
}
