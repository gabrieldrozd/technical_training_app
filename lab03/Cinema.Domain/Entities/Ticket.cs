using Cinema.Domain.ValueObject;

namespace Cinema.Domain.Entities;

public class Ticket
{
    protected Ticket()
    {
    }

    public Ticket(string email, int peopleCount)
    {
        Email = email;
        PeopleCount = peopleCount;
        PurchaseDate = DateTime.UtcNow;
        Id = new Id<Ticket>(Guid.NewGuid());
    }

    public string Email { get; set; }
    public Id<Ticket> Id { get; set; }
    public int PeopleCount { get; set; }
    public DateTime PurchaseDate { get; set; }
    public Id<Seance> SeanceId { get; set; }
}
