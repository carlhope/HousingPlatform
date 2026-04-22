using MediatR;

namespace Housing.Api.Features.Properties.Create;

public static class CreatePropertyEndpoint
{
    public static IEndpointRouteBuilder MapCreateProperty(this IEndpointRouteBuilder group)
    {
        group.MapPost("/", async (CreatePropertyCommand cmd, IMediator mediator) =>
        {
            var id = await mediator.Send(cmd);
            return Results.Created($"/properties/{id}", id);
        });

        return group;
    }
}

