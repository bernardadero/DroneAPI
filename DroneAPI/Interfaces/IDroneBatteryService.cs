using DroneAPI.DTO;
using DroneAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DroneAPI.Interfaces;

public interface IDroneBatteryService
{
    DroneBatteryRequest.CreateDroneBatteryResponse Create(DroneBatteryRequest.CreateDroneBatteryRequest request);
    object GetBroneBatteryById(int id);
}