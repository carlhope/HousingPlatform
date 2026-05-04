using MediatR;

namespace Housing.Api.Features.Owner.Update;

public static class UpdateOwnerEndpoint
{
    public static RouteHandlerBuilder MapUpdateOwner(this IEndpointRouteBuilder group)
    {
        return group.MapPut("/{id}", async (
            Guid id,
            UpdateOwnerRequest req,
            ISender sender) =>
        {
            var command = new UpdateOwnerCommand(
                id,
                req.Name,
                req.email,
                req.phone
            );

            var result = await sender.Send(command);

            return Results.Ok(result);
        });
    }
}