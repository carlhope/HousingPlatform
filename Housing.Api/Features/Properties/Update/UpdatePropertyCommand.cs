using Housing.Api.Contracts.Properties;
using MediatR;

namespace Housing.Api.Features.Properties.Update;

public record UpdatePropertyCommand(
    Guid Id,
    string Name,
    string Address,
    int Bedrooms,
    Guid OwnerId,
    Guid LandlordId
) : IRequest<PropertyDto>;
