using Cinema.Domain.Entities;
using Cinema.Domain.ValueObject;

namespace Cinema.Domain.DTOs;

public class TicketDetailsDto
{
    public TicketDetailsDto(string email, int peopleCount, Id<Ticket> id, DateTime purchaseDate)
    {
        Email = email;
        PeopleCount = peopleCount;
        Id = id;
        PurchaseDate = purchaseDate;
    }
    
    public string Email { get; }
    public int PeopleCount { get; }
    public Id<Ticket> Id { get; }
    public DateTime PurchaseDate { get; }
}