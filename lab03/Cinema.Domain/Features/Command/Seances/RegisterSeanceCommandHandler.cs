using Cinema.Domain.Entities;
using Cinema.Domain.Repositories;
using Cinema.Domain.ValueObject;

namespace Cinema.Domain.Features.Command.Seances;

public class RegisterSeanceCommandHandler : ICommandHandler<RegisterSeanceCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterSeanceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public Result Handle(RegisterSeanceCommand command)
    {
        var validationResult = new RegisterSeanceCommandValidator().Validate(command);
        if (!validationResult.IsValid) return Result.Fail(validationResult);

        var movieId = new Id<Entities.Movie>(command.MovieId);

        var doesSeanceExist = _unitOfWork.MoviesRepository.IsSeanceExist(command.SeanceDate);
        if (doesSeanceExist) return Result.Fail("This seance already exist");

        var movie = _unitOfWork.MoviesRepository.GetById(movieId);
        if (movie == null) return Result.Fail("This movie does not exist");

        var seance = new Seance(command.SeanceDate, movieId);
        
        movie.Seances.Add(seance);
        _unitOfWork.Commit();
        
        return Result.Ok();
        
        // TODO: sam koniec 18 strony (1 linijka) i początek 19*
    }
}