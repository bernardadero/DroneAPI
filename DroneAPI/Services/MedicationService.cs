using DroneAPI.Database.Interfaces;
using DroneAPI.DTO;
using DroneAPI.Interfaces;
using DroneAPI.Models;

namespace DroneAPI.Utilities;

public class MedicationService : IMEdicationService
{
    private IMedicationRepository _repository;
    public MedicationService(IMedicationRepository repository)
    {
        _repository = repository;
    }
   // public MedicationRequest.CreateMedicationRequest Create(MedicationRequest.CreateMedicationResponse request)
    public MedicationRequest.CreateMedicationResponse Create(MedicationRequest.CreateMedicationRequest request)
    {

        
        var medication = new MedicationModel
        {
            Name = request.Name,
            Weight = request.Weight,
            Code = request.Code,
            Image = request.Image,
        };
     
        int id = _repository.Add(medication);

        return new MedicationRequest.CreateMedicationResponse
        {
            Id = id,
            Message = id == 0 ? "An error occured while adding medicine" : "Medicine added successfully",
            Status = id > 0
        };

    }

    public decimal GetMedicineWeight(int id)
    {
        var capacity = _repository.GetMedicineWeight(id);
        return capacity;
    }

    object IMEdicationService.GetAll()
    {
        var medications = _repository.GetAll();
        return medications;
    }
}