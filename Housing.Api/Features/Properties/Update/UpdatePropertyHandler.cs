using Housing.Api.Contracts.Properties;
using Housing.Domain.Entities;
using Housing.Infrastructure.Persistence;
using MediatR;

namespace Housing.Api.Features.Properties.Update;

public class UpdatePropertyHandler 
    : IRequestHandler<UpdatePropertyCommand, PropertyDto>
{
    private readonly HousingDbContext _db;

    public UpdatePropertyHandler(HousingDbContext db)
    {
        _db = db;
    }

    public async Task<PropertyDto> Handle(
        UpdatePropertyCommand cmd,
        CancellationToken ct)
    {
        var property = await _db.Properties.FindAsync(new object[] { cmd.Id }, ct);

        if (property is null)
            throw new KeyNotFoundException("Property not found");

        property.UpdateDetails(
            cmd.Name,
            cmd.Address,
            cmd.Bedrooms,
            cmd.Rent
        );

        await _db.SaveChangesAsync(ct);

        return new PropertyDto(
            property.Id,
            property.Name,
            property.Address,
            property.Bedrooms,
            property.Rent
        );
    }
}