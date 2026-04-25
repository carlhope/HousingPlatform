using Microsoft.AspNetCore.Routing;

namespace Housing.Api.Features.Properties.List;

public static class ListPropertiesEndpoint
{
    public static RouteHandlerBuilder MapListProperties(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/", async (
            ListPropertiesHandler handler,
            ListPropertiesValidator validator) =>
        {
            var query = new ListPropertiesQuery();

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await handler.Handle(query);
        });
    }
}

