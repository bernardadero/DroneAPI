using DroneAPI.Database.Interfaces;
using DroneAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DroneAPI.Database.Impl;

public class MedicationRepository : IMedicationRepository
{
    private DroneAPIContext _context;
    
    public MedicationRepository(DroneAPIContext context)
    {
        _context = context;
    }
    public int Add(MedicationModel medication)
    {
        _context.MedicationModel?.Add(medication);
        _context.SaveChanges();
        return medication.Id;
    }

    public MedicationModel? GetById(int id)
    {
        return _context.MedicationModel?.SingleOrDefault(x => x.Id == id);
    }

    public List<MedicationModel>? GetAll()
    {
        return _context.MedicationModel?.ToList();
    }


    public void Delete(int id)
    {
        MedicationModel? medication = _context.MedicationModel?.SingleOrDefault(x => x.Id == id);
        if (medication == null)
        {
            return;
        }

        _context.MedicationModel?.Remove(medication);
        _context.SaveChanges();
    }

   
    public decimal GetMedicineWeight(int id)
    {
        return _context.MedicationModel
               .Where(b => b.Id == id)
               .Select(b => b.Weight)
               .SingleOrDefault();
    }

    public List<MedicationModel>? GetAllLoadedMedicineByDroneId(int id)
    {
        throw new NotImplementedException();
    }

    public object GetAllLoadedMedicineIdByDroneIds(List<int>? medId)
    {
        return _context.MedicationModel
              .Where(b => medId.Contains(b.Id))
              .Select(b => b.Name)
              .ToList();


    }
}