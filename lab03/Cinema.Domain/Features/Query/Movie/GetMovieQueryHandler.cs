using Cinema.Domain.DTOs;
using Cinema.Domain.Repositories;
// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace Cinema.Domain.Features.Query.Movie;

public class GetMovieQueryHandler : IQueryHandler<GetMovieQuery, MovieDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMovieQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public MovieDetailsDto Handle(GetMovieQuery query)
    {
        var movie = _unitOfWork.MoviesRepository.GetById(query.MovieId);
        if (movie == null) 
            throw new NullReferenceException("Given movie does not exist");

        var seances = new List<SeanceDto>();

        if (movie.Seances != null)
        {
            seances = movie.Seances
                .Select(item => new SeanceDto(item.Id.Value, item.Date))
                .ToList();
        }

        return new MovieDetailsDto(movie.Id.Value, movie.Name, movie.Year, movie.SeanceTime, seances);
    }
}