namespace Housing.Api.Contracts.Properties;

public record PropertyDto(Guid Id, string Name, string Address, int Bedrooms, decimal Rent);
