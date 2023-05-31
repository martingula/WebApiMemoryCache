namespace WebApiMemoryCache.Api.Controllers;

[Route("api/[controller]")]
public class VehicleController : Controller
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<VehicleEntity> vehicles = await _vehicleService.GetAllAsync();

        return Ok(vehicles);
    }
}