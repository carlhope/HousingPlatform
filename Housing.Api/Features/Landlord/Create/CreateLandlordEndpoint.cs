using MediatR;

namespace Housing.Api.Features.Landlord.Create;

public static class CreateLandlordEndpoint
{
    public static IEndpointRouteBuilder MapCreateLandlord(this IEndpointRouteBuilder group)
    {
        group.MapPost("/", async (CreateLandlordRequest req, IMediator mediator) =>
        {
            CreateLandlordCommand cmd =
                new CreateLandlordCommand(
                    req.Name,
                    req.Email,
                    req.Phone,
                    req.LandlordType
                    );
            
            var id = await mediator.Send(cmd);
            return Results.Created($"/landlords/{id}", id);
        });

        return group;
    }
}