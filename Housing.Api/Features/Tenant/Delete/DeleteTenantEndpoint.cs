using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Api.Features.Tenant.Delete;

public static class DeleteTenantEndpoint
{
    public static RouteHandlerBuilder MapTenantProperty(this IEndpointRouteBuilder group)
    {
        return group.MapDelete("/{id}", async (
            Guid id,
            [FromServices]IMediator mediator,
            [FromServices]DeleteTenantValidator validator) =>
        {
            var command = new DeleteTenantCommand(id);

            var validation = await validator.ValidateAsync(command);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(command);
        });
    }
}