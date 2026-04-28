using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Properties.Delete;

    public class DeletePropertyHandler: IRequestHandler<DeletePropertyCommand, IResult>
    {
        private readonly HousingDbContext _db;
        private readonly ICacheService _cache;

        public DeletePropertyHandler(HousingDbContext db, ICacheService cache)
        {
            _db = db;
            _cache = cache;
        }

        public async Task<IResult> Handle(DeletePropertyCommand command, CancellationToken ct)
        {
            var property = await _db.Properties.FindAsync([command.Id], ct);
            if (property is null)
                return Results.NotFound();

            property.SoftDelete();
            await _db.SaveChangesAsync(ct);
            
            // Invalidate caches
            await _cache.RemoveAsync($"property:{property.Id}");
            await _cache.RemoveAsync("properties:all");
            await _cache.RemoveAsync($"properties:landlord:{property.LandlordId}");
            await _cache.RemoveAsync($"properties:owner:{property.OwnerId}");

            return Results.NoContent();
        }
    }
