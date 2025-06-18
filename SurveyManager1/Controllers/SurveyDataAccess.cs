// Controllers/HomeController.cs


internal class SurveyDataAccess
{
    private IConfiguration configuration;

    public SurveyDataAccess(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    internal string? GetSurveys()
    {
        throw new NotImplementedException();
    }
}