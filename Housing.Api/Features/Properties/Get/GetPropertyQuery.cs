using Housing.Domain.Entities;
using MediatR;

namespace Housing.Api.Features.Properties.Get;

public sealed record GetPropertyQuery(Guid Id):IRequest<IResult>;

