using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Housing.Api.Features.Owner.Delete;

public static class DeleteOwnerEndpoint
{
    public static RouteHandlerBuilder MapDeleteOwner(this IEndpointRouteBuilder group)
    {
        return group.MapDelete("/{id}", async (
            Guid id,
            [FromServices]IMediator mediator,
            [FromServices]DeleteOwnerValidator validator) =>
        {
            var command = new DeleteOwnerCommand(id);

            var validation = await validator.ValidateAsync(command);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(command);
        });
    }
}