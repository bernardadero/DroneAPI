using DroneAPI.DTO;
using DroneAPI.Interfaces;
using DroneAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DroneAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoadMedicineController : ControllerBase
{
    private ILoadedMedicineService _droneService;
    
    public LoadMedicineController(ILoadedMedicineService droneService)
    {
        _droneService = droneService;
    }
    
    [Route("create")]
    [Description("Load drones with medicine")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoadedMedicineRequest.LoadedMedicineResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public  ActionResult<LoadedMedicineRequest.LoadedMedicineResponse> LoadMedicine(LoadedMedicineRequest.CreateLoadedMedicineRequestDroneRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage));
        }

        var response = _droneService.Create(request);
        if (response.Status)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }


    [HttpGet("{id}")]
    [Description("checking loaded medication items for a given drone")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoadedMedicineRequest.LoadedMedicineResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public List<string> CheckLoadedMedicineForAgivenDrone(int id)
    {

        var response = _droneService.GetMedicineyByDroneId(id);
        return (List<string>)response;
    }
}