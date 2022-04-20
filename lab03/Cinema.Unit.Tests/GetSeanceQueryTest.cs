using System.Linq;
using Cinema.Domain.Features.Query.Movie;
using Cinema.Domain.Features.Query.Seance;
using Cinema.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Cinema.Unit.Tests;

public class GetSeanceQueryTest
{
    [Fact]
    public void GetSeance_WhenItExists_ShouldSuccess()
    {
        using (var sut = new SystemUnderTest())
        {
            var movie = sut.CreateMovie("Harry Potter", 2001, 150);
            var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

            unitOfWorkSubstitute.MoviesRepository.GetSeanceDetails(movie.Id).Returns(movie);

            var query = new GetSeanceQuery(movie.Id.Value, movie.Seances.First().Id.Value);
            var queryHandler = new GetSeanceQueryHandler(unitOfWorkSubstitute);
            var moviesQuery = queryHandler.Handle(query);

            moviesQuery.MovieName.Should().Be("Harry Potter");
        }
    }
}