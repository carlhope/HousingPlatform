using MediatR;

namespace Housing.Api.Features.Landlord.List;

public sealed record ListLandlordQuery:IRequest<IResult>;