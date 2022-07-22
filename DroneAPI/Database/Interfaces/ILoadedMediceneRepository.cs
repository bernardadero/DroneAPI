using DroneAPI.DTO;
using DroneAPI.Models;

namespace DroneAPI.Database.Interfaces;

public interface ILoadedMediceneRepository
{
    int Add(LoadedMedicineModel loaded);

    LoadedMedicineModel? GetById(int id);

    List<int>? GetAllLoadedMedicineIdByDroneId(int id);

    List<LoadedMedicineModel>? GetAll();
    void Delete(int id);
   
}