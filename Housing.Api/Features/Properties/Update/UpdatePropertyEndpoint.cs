using Housing.Api.Features.Properties.Update;
using Housing.Domain.Entities;
using Housing.Infrastructure.Persistence;
using MediatR;

namespace Housing.Api.Features.Properties;

public static class UpdatePropertyEndpoint
{
    public static RouteHandlerBuilder MapUpdateProperty(this IEndpointRouteBuilder group)
    {
        return group.MapPut("/{id}", async (
            Guid id,
            UpdatePropertyRequest req,
            ISender sender) =>
        {
            var command = new UpdatePropertyCommand(
                id,
                req.Name,
                req.Address,
                req.Bedrooms,
                req.Rent
            );

            var result = await sender.Send(command);

            return Results.Ok(result);
        });
    }
}

