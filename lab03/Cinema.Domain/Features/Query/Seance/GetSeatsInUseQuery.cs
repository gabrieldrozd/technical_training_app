using Cinema.Domain.ValueObject;

namespace Cinema.Domain.Features.Query.Seance;

public class GetSeatsInUseQuery : IQuery<int>
{
    public GetSeatsInUseQuery(Id<Entities.Movie> movieId, DateTime seanceDate)
    {
        MovieId = movieId;
        SeanceDate = seanceDate;
    }
    
    public Id<Entities.Movie> MovieId { get; }
    public DateTime SeanceDate { get; }
}