using Housing.Domain.Entities;
using Housing.Infrastructure.Persistence;
using MediatR;

namespace Housing.Api.Features.Properties.Create;

public static class CreateProperty
{
    public static RouteHandlerBuilder MapCreateProperty(this IEndpointRouteBuilder group)
    {
        return group.MapPost("/", async (CreatePropertyCommand cmd, IMediator mediator) =>
        {
            var id = await mediator.Send(cmd);
            return Results.Created($"/properties/{id}", id);
        });

    }
}
