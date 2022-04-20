using System;
using Cinema.Domain.Entities;
using Cinema.Unit.Tests.Models;

namespace Cinema.Unit.Tests;

public class SystemUnderTest : IDisposable
{
    public void Dispose()
    {
    }

    public Movie CreateMovie(string name, int year, int seanceTime)
    {
        var movie = new MovieProxy(name, year, seanceTime);
        movie.Seances.Add(new SeanceProxy(new DateTime(2020, 2, 28, 13, 0, 0), movie.Id));
        movie.Seances.Add(new SeanceProxy(new DateTime(2022, 3, 1, 13, 0, 0), movie.Id));
        movie.Seances.Add(new SeanceProxy(new DateTime(2022, 3, 1, 17, 0, 0), movie.Id));

        return movie;
    }
}