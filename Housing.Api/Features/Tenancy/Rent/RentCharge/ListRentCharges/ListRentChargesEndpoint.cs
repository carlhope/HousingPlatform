using MediatR;

namespace Housing.Api.Features.Tenancy.Rent.RentCharge.ListRentCharges;

public static class ListRentChargesEndpoint
{
 
    public static RouteHandlerBuilder MapListRentCharges(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/{tenancyId:guid}", async (
            Guid tenancyId,
            IMediator mediator,
            ListRentChargesValidator validator) =>
        {
            var query = new ListRentChargesQuery(tenancyId);

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}