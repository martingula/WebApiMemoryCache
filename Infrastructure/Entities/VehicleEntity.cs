﻿namespace WebApiMemoryCache.Infrastructure.Entities;

public class VehicleEntity
{
    public int Id { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }
    public string? Type { get; set; }
    public string? Vin { get; set; }
    public string? Fuel { get; set; }
}
