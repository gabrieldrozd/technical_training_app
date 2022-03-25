using FluentValidation;

namespace Cinema.Domain.Features.Command.Movie;

public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
{
    public AddMovieCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Year).InclusiveBetween(1900, 2040);
        RuleFor(x => x.SeanceTime).InclusiveBetween(30, 300);
    }
}