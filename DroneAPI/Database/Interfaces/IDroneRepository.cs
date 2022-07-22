using DroneAPI.DTO;
using DroneAPI.Models;

namespace DroneAPI.Database.Interfaces;

public interface IDroneRepository
{
    int Add(Drone drone);

    Drone? GetById(int id);

    List<Drone>? GetAll();

    List<Drone>? GetAvailableDroneForLoading();

    decimal GetDroneWeightCapacity(int id);

    void Delete(int id);
   
}