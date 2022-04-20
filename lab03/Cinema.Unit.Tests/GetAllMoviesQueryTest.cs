using System.Collections.Generic;
using Cinema.Domain.Entities;
using Cinema.Domain.Features.Query.Movie;
using Cinema.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Cinema.Unit.Tests;

public class GetAllMoviesQueryTest
{
    [Fact]
    public void GetMovie_WhenItExists_ReturnCorrectData()
    {
        using (var sut = new SystemUnderTest())
        {
            var movie = sut.CreateMovie("Harry Potter", 2001, 150);
            var movies = new List<Movie> {movie};
            var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

            unitOfWorkSubstitute.MoviesRepository.GetAll().Returns(movies);

            var query = new GetAllMoviesQuery();
            var queryHandler = new GetAllMoviesQueryHandler(unitOfWorkSubstitute);
            var moviesQuery = queryHandler.Handle(query);

            moviesQuery[0].Name.Should().Be("Harry Potter");
        }
    }
    
    [Fact]
    public void GetMovie_WhenItExists_ShouldSuccess()
    {
        using (var sut = new SystemUnderTest())
        {
            var movie = sut.CreateMovie("Harry Potter", 2001, 150);
            var movies = new List<Movie> {movie};
            var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

            unitOfWorkSubstitute.MoviesRepository.GetAll().Returns(movies);

            var query = new GetAllMoviesQuery();
            var queryHandler = new GetAllMoviesQueryHandler(unitOfWorkSubstitute);
            var moviesQuery = queryHandler.Handle(query);

            moviesQuery.Count.Should().Be(1);
        }
    }
}