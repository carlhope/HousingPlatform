using MediatR;

namespace Housing.Api.Features.Owner.Create;

public static class CreateOwnerEndpoint
{
    public static IEndpointRouteBuilder MapCreateOwner(this IEndpointRouteBuilder group)
    {
        group.MapPost("/", async (CreateOwnerRequest req, IMediator mediator) =>
        {
            CreateOwnerCommand cmd =
                new CreateOwnerCommand(
                    req.Name,
                    req.Email,
                    req.Phone
                );
            
            var id = await mediator.Send(cmd);
            return Results.Created($"/owners/{id}", id);
        });

        return group;
    }
}