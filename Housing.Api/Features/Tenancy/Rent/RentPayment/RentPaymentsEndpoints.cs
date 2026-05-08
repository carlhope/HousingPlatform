using Housing.Api.Features.Tenancy.Rent.RentCharge.AddRentCharge;
using Housing.Api.Features.Tenancy.Rent.RentCharge.ListRentCharges;
using Housing.Api.Features.Tenancy.Rent.RentPayment.AddRentPayment;
using Housing.Api.Features.Tenancy.Rent.RentPayment.ListRentPayment;

namespace Housing.Api.Features.Tenancy.Rent.RentPayment;

public static class RentPaymentsEndpoints
{
    public static void MapRentPaymentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/{tenancyId:guid}/rent-charges");

        group.MapCreateRentPayment();
        group.MapListRentPayments();
    }
}