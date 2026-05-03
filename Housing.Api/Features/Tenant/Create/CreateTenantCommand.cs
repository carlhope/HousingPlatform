using MediatR;

namespace Housing.Api.Features.Tenant.Create;

    public sealed record CreateTenantCommand(
    string FirstName,
    string LastName,
    string Email,
    string Phone
    ) : IRequest<Guid>;