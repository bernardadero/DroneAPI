using DroneAPI.DTO;
using DroneAPI.Models;

namespace DroneAPI.Database.Interfaces;

public interface IMedicationRepository
{
    int Add(MedicationModel medication);

    MedicationModel? GetById(int id);

    List<MedicationModel>? GetAll();

    decimal GetMedicineWeight(int id);

    void Delete(int id);
    List<MedicationModel>? GetAllLoadedMedicineByDroneId(int id);
    object GetAllLoadedMedicineIdByDroneIds(List<int>? medId);
}