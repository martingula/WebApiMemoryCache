namespace WebApiMemoryCache.Application.Services.Interfaces;

public interface IVehicleService
{
    Task<List<VehicleEntity>> GetAllAsync();
}