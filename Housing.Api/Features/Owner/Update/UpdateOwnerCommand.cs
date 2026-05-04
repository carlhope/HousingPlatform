using Housing.Api.Contracts.Owners;
using MediatR;

namespace Housing.Api.Features.Owner.Update;

public record UpdateOwnerCommand(
    Guid Id,
    string Name,
    string ContactEmail,
    string ContactPhone
) : IRequest<OwnerDto>;