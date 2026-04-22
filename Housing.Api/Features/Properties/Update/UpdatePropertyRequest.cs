namespace Housing.Api.Features.Properties.Update;

public record UpdatePropertyRequest(string Name, string Address, int Bedrooms, decimal Rent);
