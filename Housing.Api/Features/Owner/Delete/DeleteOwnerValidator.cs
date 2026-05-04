using FluentValidation;

namespace Housing.Api.Features.Owner.Delete;

public sealed class DeleteOwnerValidator : AbstractValidator<DeleteOwnerCommand>
{
    public DeleteOwnerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}