using MediatR;

namespace Housing.Api.Features.Landlord.List;

public static class ListLandlordEndpoint
{
 
    public static RouteHandlerBuilder MapListLandlords(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/", async (
            IMediator mediator,
            ListLandlordValidator validator) =>
        {
            var query = new ListLandlordQuery();

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}