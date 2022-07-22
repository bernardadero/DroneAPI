using DroneAPI.Database.Interfaces;
using DroneAPI.Models;
namespace DroneAPI.Database.Impl;

public class DroneRepository : IDroneRepository
{
    private DroneAPIContext _context;
    
    public DroneRepository(DroneAPIContext context)
    {
        _context = context;
    }
    public int Add(Drone drone)
    {
        _context.Drone?.Add(drone);
        _context.SaveChanges();
        return drone.Id;
    }

    public Drone? GetById(int id)
    {
        return _context.Drone?.SingleOrDefault(x => x.Id == id);
    }

    public List<Drone>? GetAll()
    {
        return _context.Drone?.ToList();
    }

    public List<Drone>? GetAvailableDroneForLoading()
    {
        return _context.Drone
               .Where(b => b.State == 0)
               .Where(b => b.BatteryCapacity >= 25)
               .ToList();
    }

    public decimal GetDroneWeightCapacity(int id)
    {
        return _context.Drone
               .Where(b => b.Id == id)
               .Select(b => b.WeightLimit)
               .SingleOrDefault();
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