using Housing.Api.Contracts.tenants;
using MediatR;

namespace Housing.Api.Features.Tenant.Update;

public record UpdateTenantCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone
    ): IRequest<TenantDto>;
