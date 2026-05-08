using MediatR;

namespace Housing.Api.Features.Tenancy.Rent.RentPayment.AddRentPayment;

public record CreateRentPaymentCommand(
    
    Guid TenancyId,  
    decimal Amount,
    string Reference
    
    ): IRequest<Guid>;
    