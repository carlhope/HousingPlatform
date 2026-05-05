using MediatR;

namespace Housing.Api.Features.Tenancy.List;


public static class ListTenanciesEndpoint
{
 
    public static RouteHandlerBuilder MapListTenancies(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/", async (
            IMediator mediator,
            ListTenanciesValidator validator) =>
        {
            var query = new ListTenanciesQuery();

            var validation = await validator.ValidateAsync(query);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            return await mediator.Send(query);
        });
    }
}