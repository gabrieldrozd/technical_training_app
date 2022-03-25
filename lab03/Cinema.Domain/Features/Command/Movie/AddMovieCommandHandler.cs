using Cinema.Domain.Repositories;

namespace Cinema.Domain.Features.Command.Movie;

public class AddMovieCommandHandler : ICommandHandler<AddMovieCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Result Handle(AddMovieCommand command)
    {
        var validationResult = new AddMovieCommandValidator().Validate(command);
        if (!validationResult.IsValid) return Result.Fail(validationResult);

        var doesExist = _unitOfWork.MoviesRepository.IsMovieExist(command.Name, command.Year);
        if (!doesExist) return Result.Fail("Movie already exists");

        var movie = new Entities.Movie(command.Name, command.Year, command.SeanceTime);
        _unitOfWork.MoviesRepository.Add(movie);
        _unitOfWork.Commit();
        
        return Result.Ok();
    }
}