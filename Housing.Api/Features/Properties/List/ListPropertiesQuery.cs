using MediatR;

namespace Housing.Api.Features.Properties.List;

public record ListPropertiesQuery:IRequest<IResult>;

