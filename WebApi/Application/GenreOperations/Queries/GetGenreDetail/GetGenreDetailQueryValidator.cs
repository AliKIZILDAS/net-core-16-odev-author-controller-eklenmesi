using FluentValidation;

namespace WebApi.Application.GenreOperations.Quries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(x=>x.GenreId).GreaterThan(0);
        }
    }
}