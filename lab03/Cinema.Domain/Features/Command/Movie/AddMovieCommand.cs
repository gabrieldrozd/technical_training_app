namespace Cinema.Domain.Features.Command.Movie;

public sealed class AddMovieCommand : ICommand
{
    public string Name { get; set; }
    public int Year { get; set; }
    public int SeanceTime { get; set; }
}