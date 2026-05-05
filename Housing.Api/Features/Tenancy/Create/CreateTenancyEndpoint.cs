using MediatR;

namespace Housing.Api.Features.Tenancy.Create;

public static class CreateTenancyEndpoint
{
    public static IEndpointRouteBuilder MapCreateTenancy(this IEndpointRouteBuilder group)
    {
        group.MapPost("/", async (CreateTenancyRequest req, IMediator mediator) =>
        {
            CreateTenancyCommand cmd =
                new CreateTenancyCommand(
                   req.PropertyId,
                   req.LandlordId,
                   req.TenantIds,
                   req.StartDate
                );
            
            var id = await mediator.Send(cmd);
            return Results.Created($"/tenancy/{id}", id);
        });

        return group;
    }
}