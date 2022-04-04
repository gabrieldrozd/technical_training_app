using Cinema.Domain.Repositories;

namespace Cinema.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CinemaTicketDbContext _context;

    public UnitOfWork(CinemaTicketDbContext context)
    {
        _context = context;
        MoviesRepository = new MoviesRepository(context);
    }
    
    public IMoviesRepository MoviesRepository { get; }
    
    public void Dispose()
    {
        _context.Dispose();
    }
    
    public void Commit()
    {
        _context.SaveChanges();
    }
}