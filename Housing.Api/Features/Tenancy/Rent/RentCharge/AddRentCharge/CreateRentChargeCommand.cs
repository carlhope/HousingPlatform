using MediatR;

namespace Housing.Api.Features.Tenancy.Rent.RentCharge.AddRentCharge;

public record CreateRentChargeCommand(
    
    Guid TenancyId,  
    decimal Amount,
    DateTime StartDate,
    string Reason
    
    ): IRequest<Guid>;