using FluentValidation;

namespace WebApi.Application.AuthorOperatons.Commands.CreateAuthor

{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(x=>x.Model.Surname).NotEmpty().MinimumLength(2);
            RuleFor(x=>x.Model.BirthDay.Date).NotEmpty().LessThan(System.DateTime.Now.Date);
        }
    }
}