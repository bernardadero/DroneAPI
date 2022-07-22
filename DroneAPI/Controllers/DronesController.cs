using DroneAPI.DTO;
using DroneAPI.Interfaces;
using DroneAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DroneAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DronesController : ControllerBase
{
    private IDroneService _droneService;
    
    public DronesController(IDroneService droneService)
    {
        _droneService = droneService;
    }
    
    [Route("create")]
    [Description("Register drones")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DroneRequest.CreateDroneResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public  ActionResult<DroneRequest.CreateDroneResponse> Create(DroneRequest.CreateDroneRequest request)
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
    [Route("getalldrones")]
    [Description("View all drones")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DroneRequest.CreateDroneResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public List<Drone> GetDrone()
     {

        var response =  _droneService.GetAll();
        return (List<Drone>)response;
    }

    [Route("checkavailabledroneforloading")]
    [Description("Check available drones for loading")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DroneRequest.CreateDroneResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public List<Drone> CheckAvailableDronesForLoading()
    {

        var response = _droneService.GetAvailableDronesForLoading();
        return (List<Drone>)response;
    }

}