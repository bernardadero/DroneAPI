using DroneAPI.Database.Interfaces;
using DroneAPI.DTO;
using DroneAPI.Interfaces;
using DroneAPI.Models;

namespace DroneAPI.Utilities;

public class DroneBatteryService : IDroneBatteryService
{
    private IDroneBatteryepository _repository;
    public DroneBatteryService(IDroneBatteryepository repository)
    {
        _repository = repository;
    }

    public DroneBatteryRequest.CreateDroneBatteryResponse Create(DroneBatteryRequest.CreateDroneBatteryRequest request)
    {
        var battery = new BatteryLeveModel
        {
            DroneId = request.DroneId,
            CurrentBatteryLevel = request.CurrentBatteryLevel,
            LogTime = request.LogTime,
            
        };

        int id = _repository.Add(battery);

        return new DroneBatteryRequest.CreateDroneBatteryResponse
        {
            Id = id,
            Message = id == 0 ? "An error occured while adding drone battery level" : "Drone battery level added successfully",
            Status = id > 0
        };
    }

    public object GetBroneBatteryById(int id)
    {
        var availableDrones = _repository.GetById(id);
        return availableDrones;
      
    }
}