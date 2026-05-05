namespace Housing.Api.Features.Tenancy.Create;

public record CreateTenancyRequest(
    Guid PropertyId,
    Guid LandlordId,
    List<Guid> TenantIds,
    DateTime StartDate
    );