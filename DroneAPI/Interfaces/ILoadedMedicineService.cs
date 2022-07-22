using DroneAPI.DTO;
using DroneAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DroneAPI.Interfaces;

public interface ILoadedMedicineService
{
    LoadedMedicineRequest.LoadedMedicineResponse Create(LoadedMedicineRequest.CreateLoadedMedicineRequestDroneRequest request);
    object GetMedicineyByDroneId(int id);
}