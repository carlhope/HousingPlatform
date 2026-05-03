
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
    public DbSet<Tenant> Tenants => Set<Tenant>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Landlord>()
            .HasQueryFilter(l => !l.IsDeleted);
        modelBuilder.Entity<Owner>()
            .HasQueryFilter(o => !o.IsDeleted);
        modelBuilder.Entity<Property>()
            .HasQueryFilter(p => !p.IsDeleted);
        modelBuilder.Entity<RentCharge>()
            .HasQueryFilter(rc => !rc.IsDeleted);
        modelBuilder.Entity<RentPayment>()
            .HasQueryFilter(rp => !rp.IsDeleted);
        modelBuilder.Entity<Tenancy>()
            .HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<Tenant>()
            .HasQueryFilter(t => !t.IsDeleted);
    }
    public override Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Property(nameof(BaseEntity.CreatedAt)).CurrentValue = DateTime.UtcNow;


            if (entry.State == EntityState.Modified)
                entry.Property(nameof(BaseEntity.UpdatedAt)).CurrentValue = DateTime.UtcNow;

        }

        return base.SaveChangesAsync(ct);
    }


}