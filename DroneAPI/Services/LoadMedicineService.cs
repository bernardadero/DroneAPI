using DroneAPI.Database.Interfaces;
using DroneAPI.DTO;
using DroneAPI.Interfaces;
using DroneAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DroneAPI.Utilities;

public class LoadMedicineService : ILoadedMedicineService
{
    private ILoadedMediceneRepository _repository;
    private IDroneRepository _dronerepository;
    private IMedicationRepository _medicationrepository;
    public LoadMedicineService(ILoadedMediceneRepository repository,
        IDroneRepository dronerepository, IMedicationRepository medicationrepository)
    {
        _dronerepository = dronerepository;
        _repository = repository;
        _medicationrepository = medicationrepository;
    }
    

    public LoadedMedicineRequest.LoadedMedicineResponse Create(LoadedMedicineRequest.CreateLoadedMedicineRequestDroneRequest request)
{
        /// get medicine weight from medication
        decimal medicineweight = _medicationrepository.GetMedicineWeight(request.medicationId);

        /// get dron weight from droneId
        decimal dronelimit = _dronerepository.GetDroneWeightCapacity(request.DroneId);

        if (medicineweight > dronelimit)
        {
            return new LoadedMedicineRequest.LoadedMedicineResponse
            {
                Message = String.Format("Medicine weight can not exceed drone weight limit"),
            };
        }

        var medicine = new LoadedMedicineModel
        {
            DroneId = request.DroneId,  
            medicationId = request.medicationId,
        };
     
        int id = _repository.Add(medicine);

        return new LoadedMedicineRequest.LoadedMedicineResponse
        {
            Id = id,
            Message = id == 0 ? "An error occured while loading medicine on a drone" : "Drone loaded successfully",
            Status = id > 0
        };
    }

    object ILoadedMedicineService.GetMedicineyByDroneId(int id)
    {
        var medId = _repository.GetAllLoadedMedicineIdByDroneId(id);
        var allMedicines = _medicationrepository.GetAllLoadedMedicineIdByDroneIds(medId);
        return allMedicines;
    }
}