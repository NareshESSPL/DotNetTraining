// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly SurveyDataAccess _dataAccess;

    public HomeController(IConfiguration configuration)
    {
        _dataAccess = new SurveyDataAccess(configuration);
    }

    public IActionResult Index()
    {
        var surveys = _dataAccess.GetSurveys();
        return View(surveys);
    }
}