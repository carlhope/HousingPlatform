using MediatR;

namespace Housing.Api.Features.Tenant.Get;

public sealed record GetTenantQuery(Guid Id):IRequest<IResult>;