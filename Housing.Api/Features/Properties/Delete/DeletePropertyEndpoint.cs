using Microsoft.AspNetCore.Routing;

namespace Housing.Api.Features.Properties.Delete;

public static class DeletePropertyEndpoint
{
    public static RouteHandlerBuilder MapDeleteProperty(this IEndpointRouteBuilder group)
    {
        return group.MapDelete("/{id}", async (
            Guid id,
            DeletePropertyHandler handler,
            DeletePropertyValidator validator) =>
        {
            var command = new DeletePropertyCommand(id);

            var validation = await validator.ValidateAsync(command);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await handler.Handle(command);
        });
    }
}

