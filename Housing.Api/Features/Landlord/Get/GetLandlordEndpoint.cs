using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Api.Features.Landlord.Get;

public static class GetLandlordEndpoint
{
    public static RouteHandlerBuilder MapGetLandlord(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/{id}", async (
            Guid id,
            [FromServices]IMediator mediator,
            [FromServices]GetLandlordValidator validator) =>
        {
            var query = new GetLandlordQuery(id);

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}