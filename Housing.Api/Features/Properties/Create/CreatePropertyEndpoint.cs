using Housing.Api.Features.Tenant.Create;
using MediatR;

namespace Housing.Api.Features.Properties.Create;

public static class CreatePropertyEndpoint
{
    public static IEndpointRouteBuilder MapCreateProperty(this IEndpointRouteBuilder group)
    {
        group.MapPost("/", async (CreatePropertyRequest req, IMediator mediator) =>
        {
            CreatePropertyCommand cmd =
                new CreatePropertyCommand(
                    req.Name,
                    req.Address,
                    req.Bedrooms,
                    req.OwnerId,
                    req.LandlordId);
            
            var id = await mediator.Send(cmd);
            return Results.Created($"/properties/{id}", id);
        });

        return group;
    }
}

