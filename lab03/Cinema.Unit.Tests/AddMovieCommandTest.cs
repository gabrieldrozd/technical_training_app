using Cinema.Domain.Features.Command.Movie;
using Cinema.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Cinema.Unit.Tests;

public class AddMovieCommandTest
{
    [Fact]
    public void AddMovie_WhenExist_ShouldFail()
    {
        using (var sut = new SystemUnderTest())
        {
            var command = new AddMovieCommand
            {
                Name = "Harry Potter",
                Year = 2001,
                SeanceTime = 150
            };
            var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

            unitOfWorkSubstitute.MoviesRepository
                .IsMovieExist(command.Name, command.Year)
                .Returns(true);

            var handler = new AddMovieCommandHandler(unitOfWorkSubstitute);
            var result = handler.Handle(command);

            result.IsFailure.Should().Be(true);
        }
    }
    
    [Fact]
    public void AddMovie_WhenItIsPossible_ShouldSuccess()
    {
        using (var sut = new SystemUnderTest())
        {
            var command = new AddMovieCommand
            {
                Name = "Harry Potter",
                Year = 2001,
                SeanceTime = 150
            };
            var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

            var handler = new AddMovieCommandHandler(unitOfWorkSubstitute);
            var result = handler.Handle(command);

            result.IsSuccess.Should().Be(true);
        }
    }
}