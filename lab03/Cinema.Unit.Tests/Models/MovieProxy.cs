using System.Collections.Generic;
using Cinema.Domain.Entities;

namespace Cinema.Unit.Tests.Models;

public class MovieProxy : Movie
{
    public MovieProxy(string name, int year, int seanceTime) : base(name, year, seanceTime)
    {
        Seances = new List<Seance>();
    }
}