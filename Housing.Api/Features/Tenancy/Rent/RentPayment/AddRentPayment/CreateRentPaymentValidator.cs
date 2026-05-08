using FluentValidation;

namespace Housing.Api.Features.Tenancy.Rent.RentPayment.AddRentPayment;

public sealed class CreateRentPaymentValidator: AbstractValidator<CreateRentPaymentCommand>
{
    public CreateRentPaymentValidator()
    {
        RuleFor(c=>c.Amount).NotEmpty().WithMessage("Amount is required");
    }
    
}