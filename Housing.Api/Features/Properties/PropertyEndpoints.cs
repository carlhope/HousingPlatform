using Housing.Api.Features.Properties.Create;
using Housing.Domain.Entities;
using Housing.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Properties;

public static class PropertyEndpoints
{
    public static void MapPropertyEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/properties");

        group.MapListProperties();
        group.MapGetProperty();
        group.MapCreateProperty();
        group.MapUpdateProperty();
        group.MapDeleteProperty();
    }
}
