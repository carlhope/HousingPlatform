using Housing.Api.Features.Tenant.Get;
using MediatR;

namespace Housing.Api.Features.Tenant.List;

public static class ListTenantsEndpoint
{
    public static RouteHandlerBuilder MapListTenants(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/", async (
            IMediator mediator,
            ListTenantsValidator validator) =>
        {
            var query = new ListTenantsQuery();

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}