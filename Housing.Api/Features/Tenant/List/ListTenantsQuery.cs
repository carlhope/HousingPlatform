using MediatR;

namespace Housing.Api.Features.Tenant.Get;

public sealed record ListTenantsQuery:IRequest<IResult>;