using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers;

public class SeancesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}