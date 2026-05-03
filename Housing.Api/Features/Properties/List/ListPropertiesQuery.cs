using MediatR;

namespace Housing.Api.Features.Properties.List;

public sealed record ListPropertiesQuery:IRequest<IResult>;

