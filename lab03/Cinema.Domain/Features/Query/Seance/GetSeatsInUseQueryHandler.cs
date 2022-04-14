using Cinema.Domain.Repositories;

namespace Cinema.Domain.Features.Query.Seance;

public class GetSeatsInUseQueryHandler : IQueryHandler<GetSeatsInUseQuery, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSeatsInUseQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public int Handle(GetSeatsInUseQuery query)
    {
        var movie = _unitOfWork.MoviesRepository.GetById(query.MovieId);
        var seance = movie.GetSeanceByDateAndRoomId(query.SeanceDate);
        var purchasedTickets = seance.GetAllSeanceTickets();

        return purchasedTickets.Sum(x => x.PeopleCount);
    }
}