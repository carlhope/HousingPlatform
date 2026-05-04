using MediatR;

namespace Housing.Api.Features.Owner.Create;

public sealed record CreateOwnerCommand(
    string Name,
    string Email,
    string Phone
) : IRequest<Guid>;