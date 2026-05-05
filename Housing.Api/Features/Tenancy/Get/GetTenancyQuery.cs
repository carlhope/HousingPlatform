using MediatR;

namespace Housing.Api.Features.Tenancy.Get;

public sealed record GetTenancyQuery(Guid Id):IRequest<IResult>;