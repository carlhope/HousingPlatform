using Housing.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Properties.List;

public class ListPropertiesHandler
{
    private readonly HousingDbContext _db;

    public ListPropertiesHandler(HousingDbContext db)
    {
        _db = db;
    }

    public async Task<IResult> Handle(ListPropertiesQuery query)
    {
        var properties = await _db.Properties.ToListAsync();
        return Results.Ok(properties);
    }
}

