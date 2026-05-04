using Housing.Api.Contracts.Landlords;
using MediatR;

namespace Housing.Api.Features.Landlord.Update;

public record UpdateLandlordCommand(
    Guid Id,
    string Name,
    string ContactEmail,
    string ContactPhone,
    LandlordTypeDto LandordType
    ) : IRequest<LandlordDto>;