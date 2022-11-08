using FluentValidation;

namespace WebApi.Application.AuthorOperatons.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(x=>x.Id).GreaterThan(0);
            
        }
    }
}