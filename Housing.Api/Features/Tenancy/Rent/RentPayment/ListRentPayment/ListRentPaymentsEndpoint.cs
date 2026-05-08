using MediatR;

namespace Housing.Api.Features.Tenancy.Rent.RentPayment.ListRentPayment;

public static class ListRentPaymentsEndpoint
{
 
    public static RouteHandlerBuilder MapListRentPayments(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/", async (
            Guid tenancyId,
            IMediator mediator,
            ListRentPaymentsValidator validator) =>
        {
            var query = new ListRentPaymentsQuery(tenancyId);

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}