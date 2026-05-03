using Housing.Api.Features.Tenant.Create;
using Housing.Api.Features.Tenant.Delete;
using Housing.Api.Features.Tenant.Get;
using Housing.Api.Features.Tenant.List;
using Housing.Api.Features.Tenant.Update;

namespace Housing.Api.Features.Tenant;

public static class TenantEndpoints
{
    public static void MapPropertyEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/tenants");

        group.MapListTenants();
        group.MapGetTenant();
        group.MapCreateTenant();
        group.MapUpdateTenant();
        group.MapDeleteTenant();
    }
}