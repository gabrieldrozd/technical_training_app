namespace Cinema.Domain.Features.Command.Movie;

public class EditMovieCommand : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public int SeanceTime { get; set; }
}