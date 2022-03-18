using Cinema.Domain.ValueObject;

namespace Cinema.Domain.Entities;

public class Movie
{
    protected Movie()
    {
    }

    public Movie(string name, int year, int seanceTime)
    {
        Id = new Id<Movie>(Guid.NewGuid());
        Name = Name;
        Year = Year;
        SeanceTime = seanceTime;
    }
    
    public Id<Movie> Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public int SeanceTime { get; set; }
    public virtual ICollection<Seance> Seances { get; protected set; }

    public Seance GetSeanceByDateAndRoomId(DateTime date)
    {
        return Seances.SingleOrDefault(x => x.Date == date);
    }

    public void SetName(string name)
    {
        Name = name;
    }
    
    public void SetYear(int year)
    {
        Year = year;
    }

    public void SetSeanceTime(int seanceTime)
    {
        SeanceTime = seanceTime;
    }
}