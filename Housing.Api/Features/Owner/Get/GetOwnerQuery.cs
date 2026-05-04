using MediatR;

namespace Housing.Api.Features.Owner.Get;

public sealed record GetOwnerQuery(Guid Id):IRequest<IResult>;