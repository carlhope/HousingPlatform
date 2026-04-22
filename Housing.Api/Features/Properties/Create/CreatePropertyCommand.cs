using MediatR;

namespace Housing.Api.Features.Properties.Create;

public record CreatePropertyCommand(
    string Name,
    string Address,
    int Bedrooms,
    decimal Rent
) : IRequest<Guid>;