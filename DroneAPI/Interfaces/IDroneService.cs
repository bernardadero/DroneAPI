using DroneAPI.DTO;
using DroneAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DroneAPI.Interfaces;

public interface IDroneService
{
    DroneRequest.CreateDroneResponse Create(DroneRequest.CreateDroneRequest request);
    object GetAll();
    object GetAvailableDronesForLoading();
    decimal GetDroneWeightCapacity(int id);
}