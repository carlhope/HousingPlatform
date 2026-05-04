using MediatR;

namespace Housing.Api.Features.Landlord.Update;

public static class UpdateLandlordEndpoint
{
    public static RouteHandlerBuilder MapUpdateLandlord(this IEndpointRouteBuilder group)
    {
        return group.MapPut("/{id}", async (
            Guid id,
            UpdateLandlordRequest req,
            ISender sender) =>
        {
            var command = new UpdateLandlordCommand(
                id,
                req.Name,
                req.email,
                req.phone,
                req.LandlordType
            );

            var result = await sender.Send(command);

            return Results.Ok(result);
        });
    }
}