
using Microsoft.EntityFrameworkCore;

namespace Housing.Infrastructure.Persistence;

public class HousingDbContext : DbContext
{
    public HousingDbContext(DbContextOptions<HousingDbContext> options)
        : base(options)
    {
    }

    // DbSets will be added later
}