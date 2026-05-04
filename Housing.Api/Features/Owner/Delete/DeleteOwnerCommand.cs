using MediatR;

namespace Housing.Api.Features.Owner.Delete;

public record DeleteOwnerCommand(Guid Id):IRequest<IResult>;