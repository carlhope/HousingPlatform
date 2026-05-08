using Housing.Api.Features.Tenancy.Rent.RentCharge.AddRentCharge;
using Housing.Api.Features.Tenancy.Rent.RentCharge.ListRentCharges;

namespace Housing.Api.Features.Tenancy.Rent.RentCharge;

public static class RentChargeEndpoints
{
    public static void MapRentChargeEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/{tenancyId:guid}/rent-charges");

        group.MapCreateRentCharge();
        group.MapListRentCharges();
    }
}