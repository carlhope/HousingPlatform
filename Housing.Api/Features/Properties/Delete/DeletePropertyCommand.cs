using MediatR;

namespace Housing.Api.Features.Properties.Delete
{
    public record DeletePropertyCommand(Guid Id):IRequest<IResult>;
}
