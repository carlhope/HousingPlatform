using MediatR;

namespace Housing.Api.Features.Tenancy.Rent.RentCharge.AddRentCharge;

public static class CreateRentChargeEndpoint
{
    public static IEndpointRouteBuilder MapCreateRentCharge(this IEndpointRouteBuilder group)
    {
        group.MapPost("/{tenancyId:guid}", async (
            Guid tenancyId,
            CreateRentChargeRequest req,
            IMediator mediator) =>
        {
            var cmd = new CreateRentChargeCommand(
                tenancyId,
                req.Amount,
                req.StartDate,
                req.Reason
            );

            var id = await mediator.Send(cmd);

            return Results.Created(
                $"/tenancies/{tenancyId}/rent-charges/{id}",
                id
            );
        });

        return group;
    }
}
