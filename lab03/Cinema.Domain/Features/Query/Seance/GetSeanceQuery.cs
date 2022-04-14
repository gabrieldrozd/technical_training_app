using Cinema.Domain.DTOs;
using Cinema.Domain.ValueObject;

namespace Cinema.Domain.Features.Query.Seance;

public class GetSeanceQuery : IQuery<MovieSeanceDetailsDto>
{
    public GetSeanceQuery(Guid movieId, Guid seanceId)
    {
        MovieId = new Id<Entities.Movie>(movieId);
        SeanceId = new Id<Entities.Seance>(movieId);
    }

    public Id<Entities.Movie> MovieId { get; set; }
    public Id<Entities.Seance> SeanceId { get; set; }
}