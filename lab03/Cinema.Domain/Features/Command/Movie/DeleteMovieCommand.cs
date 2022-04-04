namespace Cinema.Domain.Features.Command.Movie;

public class DeleteMovieCommand : ICommand
{
    public DeleteMovieCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}