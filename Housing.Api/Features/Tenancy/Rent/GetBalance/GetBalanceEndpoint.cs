using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Api.Features.Tenancy.Rent.GetBalance;

public static class GetBalanceEndpoint
{
    public static RouteHandlerBuilder MapGetBalance(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/{id}/balance", async (
            Guid id,
            [FromServices]IMediator mediator,
            [FromServices]GetBalanceValidator validator) =>
        {
            var query = new GetBalanceQuery(id);

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}