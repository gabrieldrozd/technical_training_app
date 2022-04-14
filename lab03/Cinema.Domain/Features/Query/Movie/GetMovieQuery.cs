using Cinema.Domain.DTOs;
using Cinema.Domain.ValueObject;

namespace Cinema.Domain.Features.Query.Movie;

public class GetMovieQuery : IQuery<MovieDetailsDto>
{
    public GetMovieQuery(Guid movieId)
    {
        MovieId = new Id<Entities.Movie>(movieId);
    }
    
    public Id<Entities.Movie> MovieId { get; }
}