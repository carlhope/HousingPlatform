using MediatR;

namespace Housing.Api.Features.Owner.List;

public sealed record ListOwnerQuery:IRequest<IResult>;