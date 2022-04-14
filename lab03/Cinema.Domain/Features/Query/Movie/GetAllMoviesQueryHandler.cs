using Cinema.Domain.DTOs;
using Cinema.Domain.Repositories;

namespace Cinema.Domain.Features.Query.Movie;

public class GetAllMoviesQueryHandler : IQueryHandler<GetAllMoviesQuery, List<MovieDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public List<MovieDto> Handle(GetAllMoviesQuery query)
    {
        var movies = _unitOfWork.MoviesRepository.GetAll();

        return movies.Select(item => new MovieDto(item.Name, item.Id)).ToList();
    }
}