using DroneAPI.Database.Interfaces;
using DroneAPI.Models;
namespace DroneAPI.Database.Impl;

public class DroneBatteryRepository : IDroneBatteryepository
{
    private DroneAPIContext _context;
    
    public DroneBatteryRepository(DroneAPIContext context)
    {
        _context = context;
    }
    public int Add(BatteryLeveModel battery)
    {
        _context.BatteryLeveModel?.Add(battery);
        _context.SaveChanges();
        return battery.Id;
    }

    public BatteryLeveModel? GetById(int id)
    {
        return _context.BatteryLeveModel?.SingleOrDefault(x => x.Id == id);
    }

    public List<BatteryLeveModel>? GetAll()
    {
        return _context.BatteryLeveModel?.ToList();
    }

    public void Delete(int id)
    {
        Drone? drone = _context.Drone?.SingleOrDefault(x => x.Id == id);
        if (drone == null)
        {
            return;
        }

        _context.Drone?.Remove(drone);
        _context.SaveChanges();
    }
}