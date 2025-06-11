using Survey_System.DTO;

namespace Survey_System.Interfaces
{
    public interface ISurvey
    {
        Task<int> AddSurvey(SurveyDTO surveyDTO);
        Task<bool> UpdateSurvey(SurveyDTO surveyDTO);
        Task<bool> DeleteSurvey(int surveyId);
        Task<SurveyDTO> GetSurveyById(int surveyId);
        Task<List<SurveyDTO>> GetAllSurveys();
    }
}
