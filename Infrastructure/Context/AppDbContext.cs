namespace WebApiMemoryCache.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // Make sure the database is created, else do it
        Database.EnsureCreated();
    }

    public DbSet<VehicleEntity>? Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed database with mock data
        var id = 1;
        var vehicles = new Faker<VehicleEntity>()
            .RuleFor(v => v.Id, f => id++)
            .RuleFor(v => v.Manufacturer, f => f.Vehicle.Manufacturer())
            .RuleFor(v => v.Model, f => f.Vehicle.Model())
            .RuleFor(v => v.Type, f => f.Vehicle.Type())
            .RuleFor(v => v.Vin, f => f.Vehicle.Vin())
            .RuleFor(v => v.Fuel, f => f.Vehicle.Fuel());

        // Generate mock data - 500 items
        modelBuilder
            .Entity<VehicleEntity>()
            .HasData(vehicles.GenerateBetween(1000, 1000));
    }
}