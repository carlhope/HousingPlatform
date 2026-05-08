using MediatR;

namespace Housing.Api.Features.Tenancy.Rent.RentPayment.AddRentPayment;

public static class CreateRentPaymentEndpoint
{
    public static IEndpointRouteBuilder MapCreateRentPayment(this IEndpointRouteBuilder group)
    {
        group.MapPost("/", async (
            Guid tenancyId,
            CreateRentPaymentRequest req,
            IMediator mediator) =>
        {
            var cmd = new CreateRentPaymentCommand(
                tenancyId,
                req.Amount,
                req.Reference
            );

            var id = await mediator.Send(cmd);

            return Results.Created(
                $"/tenancies/{tenancyId}/rent-payments/{id}",
                id
            );
        });

        return group;
    }
}
