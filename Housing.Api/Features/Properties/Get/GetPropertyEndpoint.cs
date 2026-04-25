using Microsoft.AspNetCore.Routing;

namespace Housing.Api.Features.Properties.Get;

public static class GetPropertyEndpoint
{
    public static RouteHandlerBuilder MapGetProperty(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/{id}", async (
            Guid id,
            GetPropertyHandler handler,
            GetPropertyValidator validator) =>
        {
            var query = new GetPropertyQuery(id);

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await handler.Handle(query);
        });
    }
}

