using DroneAPI.Database.Interfaces;
using DroneAPI.Models;
namespace DroneAPI.Database.Impl;

public class LoadedMediceneRepository : ILoadedMediceneRepository
{
    private DroneAPIContext _context;
    
    public LoadedMediceneRepository(DroneAPIContext context)
    {
        _context = context;
    }
    public int Add(LoadedMedicineModel medicine)
    {
        _context.LoadedMedicineModel?.Add(medicine);
        _context.SaveChanges();
        return medicine.Id;
    }

    public LoadedMedicineModel? GetById(int id)
    {
        return _context.LoadedMedicineModel?.SingleOrDefault(x => x.Id == id);
    }

    public List<LoadedMedicineModel>? GetAll()
    {
        return _context.LoadedMedicineModel?.ToList();
    }


    public void Delete(int id)
    {
        LoadedMedicineModel? loadedMedicine = _context.LoadedMedicineModel?.SingleOrDefault(x => x.Id == id);
        if (loadedMedicine == null)
        {
            return;
        }

        _context.LoadedMedicineModel?.Remove(loadedMedicine);
        _context.SaveChanges();
    }

    public List<int>? GetAllLoadedMedicineIdByDroneId(int id)
    {
        return _context.LoadedMedicineModel
               .Where(b => b.DroneId == id)
               .Select(b => b.medicationId)
               .ToList();
    }
}