namespace Housing.Api.Contracts.Properties;

public sealed record PropertyDto(Guid Id, string Name, string Address, int Bedrooms);
