using Cinema.Domain.DTOs;
using Cinema.Domain.Entities;
using Cinema.Domain.Features.Command.Movie;
using Cinema.Domain.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.UI.Controllers;

public class MovieController : Controller
{
    public MovieController()
    {
    }
    
    // GET
    public IActionResult Index()
    {
        var movies = new List<MovieDto>
        {
            new MovieDto("Film 1", new Id<Movie>(Guid.NewGuid())),
            new MovieDto("Film 2", new Id<Movie>(Guid.NewGuid())),
            new MovieDto("Film 3", new Id<Movie>(Guid.NewGuid()))
        };
        
        return View(movies);
    }

    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(AddMovieCommand command)
    {
        return RedirectToAction("Index");
    }

    public IActionResult Edit(Guid id)
    {
        var model = new EditMovieCommand
        {

        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(EditMovieCommand command)
    {
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        return RedirectToAction("Index");
    }
}