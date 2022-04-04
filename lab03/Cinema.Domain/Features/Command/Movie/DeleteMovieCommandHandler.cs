using Cinema.Domain.Repositories;
using Cinema.Domain.ValueObject;

namespace Cinema.Domain.Features.Command.Movie;

public class DeleteMovieCommandHandler : ICommandHandler<DeleteMovieCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Result Handle(DeleteMovieCommand command)
    {
        var movie = _unitOfWork.MoviesRepository.GetById(new Id<Entities.Movie>(command.Id));
        if (movie == null) return Result.Fail("Movie does not exist");
        
        _unitOfWork.MoviesRepository.Remove(movie);
        _unitOfWork.Commit();
        
        return Result.Ok();
    }
}