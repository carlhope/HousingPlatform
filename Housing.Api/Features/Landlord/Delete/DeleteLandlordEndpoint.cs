using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Api.Features.Landlord.Delete;

public static class DeleteLandlordEndpoint
{
    public static RouteHandlerBuilder MapDeleteLandlord(this IEndpointRouteBuilder group)
    {
        return group.MapDelete("/{id}", async (
            Guid id,
            [FromServices]IMediator mediator,
            [FromServices]DeleteLandlordValidator validator) =>
        {
            var command = new DeleteLandlordCommand(id);

            var validation = await validator.ValidateAsync(command);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(command);
        });
    }
}