using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Landlord.Delete;

public class DeleteLandlordHandler: IRequestHandler<DeleteLandlordCommand, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public DeleteLandlordHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<IResult> Handle(DeleteLandlordCommand command, CancellationToken ct)
    {
        var landlord = await _db.Landlords.FindAsync([command.Id], ct);
        if (landlord is null)
            return Results.NotFound();

        landlord.SoftDelete();
        await _db.SaveChangesAsync(ct);
            
        // Invalidate caches
        await _cache.RemoveAsync($"landlord:{landlord.Id}");
        await _cache.RemoveAsync("landlords:all");

        return Results.NoContent();
    }
}