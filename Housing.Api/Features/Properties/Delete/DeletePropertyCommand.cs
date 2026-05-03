using MediatR;

namespace Housing.Api.Features.Properties.Delete
{
    public sealed record DeletePropertyCommand(Guid Id):IRequest<IResult>;
}
