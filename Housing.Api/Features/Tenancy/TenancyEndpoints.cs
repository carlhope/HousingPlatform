using Housing.Api.Features.Tenancy.Create;
using Housing.Api.Features.Tenancy.Get;
using Housing.Api.Features.Tenancy.List;
using Housing.Api.Features.Tenancy.Rent.GetBalance;
using Housing.Api.Features.Tenancy.Rent.RentCharge;
using Housing.Api.Features.Tenancy.Rent.RentPayment;
using Housing.Api.Features.Tenancy.Terminate;

namespace Housing.Api.Features.Tenancy;

public static class TenancyEndpoints
{
    public static void MapTenancyEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/tenancies");

        group.MapListTenancies();
        group.MapGetTenancy();
        group.MapCreateTenancy();
        group.MapTerminateTenancy();

        
        //nested endpoints
        group.MapGetBalance();
        group.MapRentChargeEndpoints();
        group.MapRentPaymentEndpoints();
    }
}