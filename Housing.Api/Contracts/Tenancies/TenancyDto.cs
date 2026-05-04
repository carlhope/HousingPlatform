using Housing.Api.Contracts.Landlords;
using Housing.Api.Contracts.Properties;
using Housing.Api.Contracts.Rent;
using Housing.Api.Contracts.tenants;

namespace Housing.Api.Contracts.Tenancies;

public sealed record TenancyDto
(
    Guid Id,
    Guid PropertyId,
    PropertyDto Property,
    List<TenantDto> Tenants,
    Guid LandlordId,
    LandlordDto Landlord,
    DateTime StartDate,
    DateTime? EndDate,
    List<RentChargeDto> RentHistory,
    List<RentPaymentDto> Payments
 
);