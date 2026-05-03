using Housing.Api.Features.Landlord.Create;
using Housing.Api.Features.Landlord.Delete;
using Housing.Api.Features.Landlord.Get;
using Housing.Api.Features.Landlord.List;
using Housing.Api.Features.Landlord.Update;

namespace Housing.Api.Features.Landlord;

public static class LandlordEndpoints
{
    public static void MapLandlordEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/landlords");

        group.MapListLandlord();
        group.MapGetLandlord();
        group.MapCreateLandlord();
        group.MapUpdateLandlord();
        group.MapDeleteLandlord();
    }
}