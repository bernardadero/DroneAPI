using DroneAPI.DTO;
using DroneAPI.Models;

namespace DroneAPI.Database.Interfaces;

public interface IDroneBatteryepository
{
    int Add(BatteryLeveModel drone);
    BatteryLeveModel? GetById(int id);
    List<BatteryLeveModel>? GetAll();
    void Delete(int id);
   
}