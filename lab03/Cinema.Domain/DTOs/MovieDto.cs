using Cinema.Domain.Entities;
using Cinema.Domain.ValueObject;

namespace Cinema.Domain.DTOs;

public class MovieDto
{
    public MovieDto(string name, Id<Movie> id)
    {
        Name = name;
        Id = id;
    }
    
    public string Name { get; }
    public Id<Movie> Id { get; }
}