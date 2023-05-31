namespace WebApiMemoryCache.Application.Services;

public class VehicleService : IVehicleService
{
    private readonly AppDbContext _dbContext;

    private const string CacheKeyVehicleList = "VehicleList";
    private readonly ICacheService _cacheService;

    public VehicleService(AppDbContext dbContext, ICacheService cacheService)
    {
        _dbContext = dbContext;
        _cacheService = cacheService;
    }

    public async Task<List<VehicleEntity>> GetAllAsync()
    {
        if (_cacheService.TryGetValue(CacheKeyVehicleList, out List<VehicleEntity>? values))
        {
            if (values != null)
            {
                return values;
            }
        }

        if (_dbContext.Vehicles != null)
        {
            var vehicles = await _dbContext.Vehicles.ToListAsync();
            
            // Sleep for 2 seconds to fake db access
            Thread.Sleep(new TimeSpan(0, 0, 2));

            _cacheService.Set(CacheKeyVehicleList, vehicles, _cacheService.GetDefaultCacheEntryOptions());
            return vehicles;
        }
        
        return new List<VehicleEntity>();
    }
}

