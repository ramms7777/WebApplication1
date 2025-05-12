using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    //public IActionResult Index()
    //{
    //    home ohome = new home();

    //    CommonServices commonServices = new CommonServices();
    //  ohome.homeparam= commonServices.PostRequest("", "http://webapitest-service:5000/WeatherForecast");
    //    ohome.autoparam = commonServices.PostRequest("", "http://webapitest-service:5000/autocad");
    //    ohome.homeparam = commonServices.PostRequest("", "http://webapitest2-service:5000/WeatherForecast");
    //    ohome.autoparam = commonServices.PostRequest("", "http://webapitest2-service:5000/autocad");
    //    return View(ohome);
    //}
    public IActionResult Index()
    {
        home ohome = new home();
        CommonServices commonServices = new CommonServices();

        // Get data from webapitest-service (port 5000)
        var homeparam1 = commonServices.PostRequest("", "http://webapitest-service:5000/WeatherForecast");
        var autoparam1 = commonServices.PostRequest("", "http://webapitest-service:5000/autocad");

        // Get data from webapitest2-service (port 4000)
        var homeparam2 = commonServices.PostRequest("", "http://webapitest2-service:5001/qumuli");
        var autoparam2 = commonServices.PostRequest("", "http://webapitest2-service:5001/brads");
        var autoparam3 = commonServices.PostRequest("", "http://webapitest2-service:5001/api/employees");
        var homeparam3 = commonServices.PostRequest("", "http://webapitest-service:5002/WeatherForecast");
        // Assign them properly (you can structure them how you need)
        ohome.homeparam = homeparam1 + "\n" + homeparam2 + "\n" + homeparam3;
        ohome.autoparam = autoparam1 + "\n" + autoparam2+"\n"+ autoparam3;

        return View(ohome);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
