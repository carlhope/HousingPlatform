using FluentValidation;

namespace Housing.Api.Features.Landlord.Delete;

public sealed class DeleteLandlordValidator : AbstractValidator<DeleteLandlordCommand>
{
    public DeleteLandlordValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}