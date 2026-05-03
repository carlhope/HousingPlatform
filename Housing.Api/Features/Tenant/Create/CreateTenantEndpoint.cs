using MediatR;

namespace Housing.Api.Features.Tenant.Create;

public static class CreateTenantEndpoint
{
    public static IEndpointRouteBuilder MapCreateTenant(this IEndpointRouteBuilder group)
    {
        group.MapPost("/", async (CreateTenantRequest req, IMediator mediator) =>
        {
            CreateTenantCommand cmd = new CreateTenantCommand(
                req.FirstName,
                req.LastName,
                req.Email,
                req.Phone
                );
            var id = await mediator.Send(cmd);
            return Results.Created($"/tenants/{id}", id);
        });

        return group;
    }
}