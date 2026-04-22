using MediatR;
using Housing.Infrastructure;
using Housing.Domain;
using Housing.Domain.Entities;
using Housing.Infrastructure.Persistence;

namespace Housing.Api.Features.Properties.Create;

public class CreatePropertyHandler : IRequestHandler<CreatePropertyCommand, Guid>
{
    private readonly HousingDbContext _db;

    public CreatePropertyHandler(HousingDbContext db)
    {
        _db = db;
    }

    public async Task<Guid> Handle(CreatePropertyCommand request, CancellationToken ct)
    {
        var property = new Property(
            request.Name,
            request.Address,
            request.Bedrooms,
            request.Rent
        );

        _db.Properties.Add(property);
        await _db.SaveChangesAsync(ct);

        return property.Id;
    }
}