using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Housing.Infrastructure.Persistence;

public class HousingDbContextFactory : IDesignTimeDbContextFactory<HousingDbContext>
{
    public HousingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HousingDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=housing;Username=housing;Password=housing");

        return new HousingDbContext(optionsBuilder.Options);
    }
}
