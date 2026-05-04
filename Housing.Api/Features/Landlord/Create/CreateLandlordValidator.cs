using System.Data;
using FluentValidation;

namespace Housing.Api.Features.Landlord.Create;

public sealed class CreateLandlordValidator : AbstractValidator<CreateLandlordCommand>

{ 
    public CreateLandlordValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x=>x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x=>x.LandlordType).NotEmpty();
        }
}