namespace Cinema.Domain.DTOs;

public class MovieDetailsDto
{
    public MovieDetailsDto(Guid id, string name, int year, int seanceTime, List<SeanceDto> seances)
    {
        Id = id;
        Name = name;
        Year = year;
        SeanceTime = seanceTime;
        Seances = seances;
    }
    
    public Guid Id { get; }
    public string Name { get; }
    public int Year { get; }
    public int SeanceTime { get; }
    public List<SeanceDto> Seances { get; }
}