namespace Housing.Api.Features.Properties.Create;
    public sealed record CreatePropertyRequest(
        string Name,
        string Address,
        int Bedrooms,
        Guid OwnerId,
        Guid LandlordId
    );