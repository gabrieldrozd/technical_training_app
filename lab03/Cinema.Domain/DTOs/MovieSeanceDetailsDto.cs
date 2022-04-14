using Cinema.Domain.Entities;
using Cinema.Domain.ValueObject;

namespace Cinema.Domain.DTOs;

public class MovieSeanceDetailsDto
{
    public MovieSeanceDetailsDto(Movie movie, Seance seance)
    {
        MovieId = movie.Id;
        MovieName = movie.Name;
        SeanceId = seance.Id;
        SeanceDate = seance.Date;
    }

    public Id<Movie> MovieId { get; set; }
    public string MovieName { get; set; }
    public Id<Seance> SeanceId { get; set; }
    public DateTime SeanceDate { get; set; }
}