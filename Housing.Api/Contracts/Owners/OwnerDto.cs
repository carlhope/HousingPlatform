namespace Housing.Api.Contracts.Owners;

public sealed record OwnerDto(
    string name,
    string contactEmail,
    string contactPhone );