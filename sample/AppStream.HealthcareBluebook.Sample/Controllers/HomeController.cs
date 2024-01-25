using System.Diagnostics;
using AppStream.HealthcareBluebook.Sample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppStream.HealthcareBluebook.Sample.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHcbbSamlResponseGenerator _hcbbSamlResponseGenerator;

    public HomeController(
        ILogger<HomeController> logger,
        IHcbbSamlResponseGenerator hcbbSamlResponseGenerator)
    {
        this._logger = logger;
        this._hcbbSamlResponseGenerator = hcbbSamlResponseGenerator;
    }

    public IActionResult Index()
    {
        return this.View();
    }

    public IActionResult Privacy()
    {
        return this.View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }

    public IActionResult GoToHcbb()
    {
        return this._hcbbSamlResponseGenerator
            .GenerateHcbbSamlResponse("insert member id here");
    }
}
