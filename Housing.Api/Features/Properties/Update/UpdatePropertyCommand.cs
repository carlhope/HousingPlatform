using MediatR;

namespace Housing.Api.Features.Properties.Update;

public record UpdatePropertyCommand(
    Guid Id,
    string Name,
    string Address,
    int Bedrooms,
    decimal Rent
) : IRequest<PropertyDto>;
