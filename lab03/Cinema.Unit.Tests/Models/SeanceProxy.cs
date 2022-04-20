using System;
using System.Collections.Generic;
using Cinema.Domain.Entities;
using Cinema.Domain.ValueObject;

namespace Cinema.Unit.Tests.Models;

public class SeanceProxy : Seance
{
    public SeanceProxy(DateTime date, Id<Movie> movieId) : base(date, movieId)
    {
        Tickets = new List<Ticket>();
    }
}