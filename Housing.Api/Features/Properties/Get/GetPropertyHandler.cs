using Housing.Infrastructure.Persistence;

namespace Housing.Api.Features.Properties.Get;

public class GetPropertyHandler
{
    private readonly HousingDbContext _db;

    public GetPropertyHandler(HousingDbContext db)
    {
        _db = db;
    }

    public async Task<IResult> Handle(GetPropertyQuery query)
    {
        var property = await _db.Properties.FindAsync(query.Id);

        return property is not null
            ? Results.Ok(property)
            : Results.NotFound();
    }
}



