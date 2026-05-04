using MediatR;

namespace Housing.Api.Features.Landlord.Delete;

public record DeleteLandlordCommand(Guid Id):IRequest<IResult>;