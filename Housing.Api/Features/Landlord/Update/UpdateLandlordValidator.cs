using FluentValidation;

namespace Housing.Api.Features.Landlord.Update;

public class UpdateLandlordValidator : AbstractValidator<UpdateLandlordCommand>
{
    public UpdateLandlordValidator()
    {
        RuleFor(x=>x.Id).NotNull();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.ContactEmail).NotEmpty().EmailAddress();
        RuleFor(x => x.ContactPhone).NotEmpty();
        RuleFor(x => x.LandordType).NotEmpty();
    }

    
}