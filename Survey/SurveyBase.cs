using Survey.DTO;

namespace Survey
{
    public abstract class SurveyBase
    {

        public virtual SurveyDTO SurveyDetails()
        {
            return new SurveyDTO();
        }

       
    }
}
