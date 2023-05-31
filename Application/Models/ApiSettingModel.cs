namespace WebApiMemoryCache.Application.Models;

public class ApiSettingModel
{
    public int CacheSlidingExpirationInSeconds { get; set; }
    public int CacheAbsoluteExpirationInSeconds { get; set; }
}