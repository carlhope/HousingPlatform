using Housing.Api.Contracts.tenants;
using MediatR;

namespace Housing.Api.Features.Tenant.Update;

public sealed record UpdateTenantCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone
    ): IRequest<TenantDto>;
