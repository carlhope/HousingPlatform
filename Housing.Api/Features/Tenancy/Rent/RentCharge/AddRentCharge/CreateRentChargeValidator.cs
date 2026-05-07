using FluentValidation;

namespace Housing.Api.Features.Tenancy.Rent.RentCharge.AddRentCharge;

public sealed class CreateRentChargeValidator: AbstractValidator<CreateRentChargeCommand>
{
    public CreateRentChargeValidator()
    {
        RuleFor(c => c.StartDate).NotEmpty().WithMessage("Start Date is required");
        RuleFor(c=>c.Amount).NotEmpty().WithMessage("Amount is required");
    }
    
}