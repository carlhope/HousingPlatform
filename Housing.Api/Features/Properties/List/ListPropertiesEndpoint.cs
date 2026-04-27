using MediatR;
using Microsoft.AspNetCore.Routing;

namespace Housing.Api.Features.Properties.List;

public static class ListPropertiesEndpoint
{
    public static RouteHandlerBuilder MapListProperties(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/", async (
            IMediator mediator,
            ListPropertiesValidator validator) =>
        {
            var query = new ListPropertiesQuery();

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}

