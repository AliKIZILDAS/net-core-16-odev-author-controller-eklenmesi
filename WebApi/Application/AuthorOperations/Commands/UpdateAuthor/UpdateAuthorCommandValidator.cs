using FluentValidation;

namespace WebApi.Application.AuthorOperatons.Commands.UpdateAuthor

{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(x=>x.Model.Surname).NotEmpty().MinimumLength(2);
            RuleFor(x=>x.Model.BirthDay.Date).NotEmpty().LessThan(System.DateTime.Now.Date);
        }
    }
}