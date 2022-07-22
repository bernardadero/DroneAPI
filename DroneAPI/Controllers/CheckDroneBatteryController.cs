using DroneAPI.DTO;
using DroneAPI.Interfaces;
using DroneAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DroneAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CheckDroneBatteryController : ControllerBase
{
    private IDroneBatteryService _droneService;
    
    public CheckDroneBatteryController(IDroneBatteryService droneService)
    {
        _droneService = droneService;
    }
    
    [Route("adddronebatterylevel")]
    [Description("Capture drone battery level")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DroneBatteryRequest.CreateDroneBatteryResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public  ActionResult<DroneBatteryRequest.CreateDroneBatteryResponse> Create(DroneBatteryRequest.CreateDroneBatteryRequest request)
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
    [Description("Check drone battery level by drone id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DroneBatteryRequest.CreateDroneBatteryResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public List<BatteryLeveModel> CheckDronebatteryLevelByDroneId(int id)
    {

        var response = _droneService.GetBroneBatteryById(id);
        return (List<BatteryLeveModel>)response;
    }

}