using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers;

public class MovieController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}