using DroneAPI.DTO;
using DroneAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DroneAPI.Interfaces;

public interface IMEdicationService
{
    MedicationRequest.CreateMedicationResponse Create(MedicationRequest.CreateMedicationRequest request);
    object GetAll();
    decimal GetMedicineWeight(int id);
}