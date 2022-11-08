using FluentValidation;

namespace WebApi.Application.AuthorOperatons.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MinimumLength(2);
            RuleFor(x=>x.Surname).NotEmpty().MinimumLength(2);
        }
    }
}