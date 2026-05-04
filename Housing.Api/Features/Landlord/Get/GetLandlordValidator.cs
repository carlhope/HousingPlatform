using FluentValidation;

namespace Housing.Api.Features.Landlord.Get;

public class GetLandlordValidator : AbstractValidator<GetLandlordQuery>
{
    GetLandlordValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}