using DroneAPI.Database.Interfaces;
using DroneAPI.DTO;
using DroneAPI.Interfaces;
using DroneAPI.Models;

namespace DroneAPI.Utilities;

public class DroneService : IDroneService
{
    private IDroneRepository _repository;
    public DroneService(IDroneRepository repository)
    {
        _repository = repository;
    }
    
    public DroneRequest.CreateDroneResponse Create(DroneRequest.CreateDroneRequest request)
    {

        if (!Enum.TryParse(request.Model, true, out DroneModelTypes droneType))
        {
            return new DroneRequest.CreateDroneResponse
            {
                Message = String.Format("Invalid drone model type {0}", request.Model),
            };
        }
        
        if (!Enum.TryParse(request.State, true, out DroneState droneState))
        {
            return new DroneRequest.CreateDroneResponse
            {
                Message = String.Format("Invalid drone state {0}", request.State),
            };
        }
        
        var drone = new Drone
        {
            SerialNumber = request.SerialNumber,
            BatteryCapacity = request.BatteryCapacity,
            Model = droneType,
            State = droneState,
            WeightLimit = request.WeightLimit,
        };
     
        int id = _repository.Add(drone);

        return new DroneRequest.CreateDroneResponse
        {
            Id = id,
            Message = id == 0 ? "An error occured while creating a drone" : "Drone created successfully",
            Status = id > 0
        };
    }

    public object GetAvailableDronesForLoading()
    {
        var availableDrones = _repository.GetAvailableDroneForLoading();
        return availableDrones;
    }
    object IDroneService.GetAll()
    {
        var availableDrones = _repository.GetAll();
        return availableDrones;
    }
    
    public decimal GetDroneWeightCapacity(int id)
    {
        var capacity = _repository.GetDroneWeightCapacity(id);
        return capacity;
    }
}