using MediatR;

namespace Housing.Api.Features.Owner.List;

public static class ListOwnerEndpoint
{
 
    public static RouteHandlerBuilder MapListOwner(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/", async (
            IMediator mediator,
            ListOwnerValidator validator) =>
        {
            var query = new ListOwnerQuery();

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}