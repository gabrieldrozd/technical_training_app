using Cinema.Domain.Repositories;
using Cinema.Domain.ValueObject;

namespace Cinema.Domain.Features.Command.Movie;

public class EditMovieCommandHandler : ICommandHandler<EditMovieCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Result Handle(EditMovieCommand command)
    {
        var validationResult = new EditMovieCommandValidator().Validate(command);
        if (!validationResult.IsValid) return Result.Fail(validationResult);

        var movie = _unitOfWork.MoviesRepository.GetById(new Id<Entities.Movie>(command.Id));
        if (movie == null) return Result.Fail("Movie does not exist");
        
        movie.SetName(command.Name);
        movie.SetYear(command.Year);
        movie.SetSeanceTime(command.SeanceTime);
        
        _unitOfWork.MoviesRepository.Update(movie);
        _unitOfWork.Commit();
        
        return Result.Ok();
    }
}