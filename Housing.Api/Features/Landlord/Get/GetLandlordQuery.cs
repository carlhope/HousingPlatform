using MediatR;

namespace Housing.Api.Features.Landlord.Get;

public sealed record GetLandlordQuery(Guid Id):IRequest<IResult>;