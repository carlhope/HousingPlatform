using FluentValidation;

namespace Housing.Api.Features.Properties.Delete
{
    public class DeletePropertyValidator : AbstractValidator<DeletePropertyCommand>
    {
        public DeletePropertyValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
