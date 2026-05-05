using MediatR;

namespace Housing.Api.Features.Tenancy.List;

public sealed record ListTenanciesQuery:IRequest<IResult>;