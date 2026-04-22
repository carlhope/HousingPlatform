
using Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Housing.Infrastructure.Persistence;

public class HousingDbContext : DbContext
{
    public HousingDbContext(DbContextOptions<HousingDbContext> options)
        : base(options)
    {
    }

    public DbSet<Property> Properties => Set<Property>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}