using Cinema.Domain.DTOs;
using Cinema.Domain.Repositories;

namespace Cinema.Domain.Features.Query.Seance;

public class GetSeanceQueryHandler : IQueryHandler<GetSeanceQuery, MovieSeanceDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSeanceQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public MovieSeanceDetailsDto Handle(GetSeanceQuery query)
    {
        var movie = _unitOfWork.MoviesRepository.GetSeanceDetails(query.MovieId);
        if (movie == null)
            throw new NullReferenceException("Given movie does not exist");

        var seance = movie.Seances.SingleOrDefault(x => x.Id == query.SeanceId);
        if (seance == null)
            throw new NullReferenceException("Given seance does not exist");

        return new MovieSeanceDetailsDto(movie, seance);
    }
}