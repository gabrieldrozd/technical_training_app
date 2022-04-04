namespace Cinema.Domain.Features.Command.Seances;

public class RegisterSeanceCommand : ICommand
{
    public Guid MovieId { get; set; }
    public DateTime SeanceDate { get; set; }
}