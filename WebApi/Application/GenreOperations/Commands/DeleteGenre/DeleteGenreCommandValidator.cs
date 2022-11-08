using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.DeleateGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x=>x.GenreId).GreaterThan(0);
        }
    }
}