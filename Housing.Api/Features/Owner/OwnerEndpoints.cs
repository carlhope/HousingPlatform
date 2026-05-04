using Housing.Api.Features.Owner.Create;
using Housing.Api.Features.Owner.Delete;
using Housing.Api.Features.Owner.Get;
using Housing.Api.Features.Owner.List;
using Housing.Api.Features.Owner.Update;

namespace Housing.Api.Features.Owner;

public static class OwnerEndpoints
{
    public static void MapOwnerEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/owners");

        group.MapListOwner();
        group.MapGetOwner();
        group.MapCreateOwner();
        group.MapUpdateOwner();
        group.MapDeleteOwner();
    }
}