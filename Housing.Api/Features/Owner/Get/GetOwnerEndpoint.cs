using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Api.Features.Owner.Get;

public static class GetOwnerEndpoint
{
    public static RouteHandlerBuilder MapGetOwner(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/{id}", async (
            Guid id,
            [FromServices]IMediator mediator,
            [FromServices]GetOwnerValidator validator) =>
        {
            var query = new GetOwnerQuery(id);

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}