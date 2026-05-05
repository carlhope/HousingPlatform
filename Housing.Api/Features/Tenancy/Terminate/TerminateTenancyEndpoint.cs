using MediatR;

namespace Housing.Api.Features.Tenancy.Terminate;

public static class TerminateTenancyEndpoint
{
    public static RouteHandlerBuilder MapTerminateTenancy(this IEndpointRouteBuilder group)
    {
        return group.MapPut("/terminate/{id}", async (
            Guid id,
            TerminateTenancyRequest req,
            ISender sender) =>
        {
            var command = new TerminateTenancyCommand(
                id,
                req.endDate
            );

            var result = await sender.Send(command);

            return Results.Ok(result);
        });
    }
}