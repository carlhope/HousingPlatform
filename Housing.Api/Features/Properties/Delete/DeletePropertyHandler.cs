using Housing.Infrastructure.Persistence;

namespace Housing.Api.Features.Properties.Delete;

    public class DeletePropertyHandler
    {
        private readonly HousingDbContext _db;

        public DeletePropertyHandler(HousingDbContext db)
        {
            _db = db;
        }

        public async Task<IResult> Handle(DeletePropertyCommand command)
        {
            var property = await _db.Properties.FindAsync(command.Id);
            if (property is null)
                return Results.NotFound();

            _db.Properties.Remove(property);
            await _db.SaveChangesAsync();

            return Results.NoContent();
        }
    }
