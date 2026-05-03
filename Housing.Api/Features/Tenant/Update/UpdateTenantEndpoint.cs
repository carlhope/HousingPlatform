using MediatR;

namespace Housing.Api.Features.Tenant.Update;

public static class UpdateTenantEndpoint
{
    public static RouteHandlerBuilder MapUpdateTenant(this IEndpointRouteBuilder group)
    {
        return group.MapPut("/{id}", async (
            Guid id,
            UpdateTenantRequest req,
            ISender sender) =>
        {
            var command = new UpdateTenantCommand(
                req.Id,
                req.FirstName,
                req.LastName,
                req.Email,
                req.Phone
            );

            var result = await sender.Send(command);

            return Results.Ok(result);
        });
    }
}