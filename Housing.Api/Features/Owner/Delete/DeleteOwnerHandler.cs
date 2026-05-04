using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Owner.Delete;

public class DeleteOwnerHandler: IRequestHandler<DeleteOwnerCommand, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public DeleteOwnerHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<IResult> Handle(DeleteOwnerCommand command, CancellationToken ct)
    {
        var owner = await _db.Owners.FindAsync([command.Id], ct);
        if (owner is null)
            return Results.NotFound();

        owner.SoftDelete();
        await _db.SaveChangesAsync(ct);
            
        // Invalidate caches
        await _cache.RemoveAsync($"owner:{owner.Id}");
        await _cache.RemoveAsync("owners:all");

        return Results.NoContent();
    }
}