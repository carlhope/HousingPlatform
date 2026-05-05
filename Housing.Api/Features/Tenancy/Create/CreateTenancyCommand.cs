using MediatR;

namespace Housing.Api.Features.Tenancy.Create;

public record CreateTenancyCommand(
    Guid PropertyId,
    Guid LandlordId,
    List<Guid> TenantIds,
    DateTime StartDate
) : IRequest<Guid>;