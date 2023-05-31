namespace WebApiMemoryCache.Api.Controllers;

[Route("api/[controller]")]
public class CacheController : Controller
{
    private readonly ICacheService _cacheService;

    public CacheController(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    [HttpPost("clear")]
    public IActionResult Clear()
    {
        _cacheService.Clear();
        return Ok();
    }
}