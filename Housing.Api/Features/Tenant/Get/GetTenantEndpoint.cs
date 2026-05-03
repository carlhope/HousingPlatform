using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Api.Features.Tenant.Get;

public static class GetTenantEndpoint
{
    public static RouteHandlerBuilder MapGetTenant(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/{id}", async (
            Guid id,
            [FromServices]IMediator mediator,
            [FromServices]GetTenantValidator validator) =>
        {
            var query = new GetTenantQuery(id);

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}