using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Api.Features.Tenancy.Get;

public static class GetTenancyEndpoint
{
    public static RouteHandlerBuilder MapGetTenancy(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/{id}", async (
            Guid id,
            [FromServices]IMediator mediator,
            [FromServices]GetTenancyValidator validator) =>
        {
            var query = new GetTenancyQuery(id);

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}