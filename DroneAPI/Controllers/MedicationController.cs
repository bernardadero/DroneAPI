using DroneAPI.DTO;
using DroneAPI.Interfaces;
using DroneAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DroneAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicationController : ControllerBase
{
    private IMEdicationService _droneService;
    
    public MedicationController(IMEdicationService droneService)
    {
        _droneService = droneService;
    }
    
    [Route("create")]
    [Description("Register medicines")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicationRequest.CreateMedicationResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public  ActionResult<MedicationRequest.CreateMedicationResponse> Create(MedicationRequest.CreateMedicationRequest request)
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
    [Route("getalllmedications")]
    [Description("Check all registerd medicines")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DroneRequest.CreateDroneResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public List<MedicationModel> GetAllMedications()
     {

        var response =  _droneService.GetAll();
        return (List<MedicationModel>)response;
    }

}