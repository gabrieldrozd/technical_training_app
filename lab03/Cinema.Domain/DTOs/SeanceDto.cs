namespace Cinema.Domain.DTOs;

public class SeanceDto
{
    public SeanceDto(Guid id, DateTime date)
    {
        Id = id;
        Date = date;
    }
    
    public Guid Id { get; }
    public DateTime Date { get; }
}