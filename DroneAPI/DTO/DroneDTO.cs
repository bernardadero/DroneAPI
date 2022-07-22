using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DroneAPI.Models;
using DroneAPI.Utilities;

namespace DroneAPI.DTO;

public class DroneRequest
{
    public class CreateDroneRequest
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter serial number")]
        public string SerialNumber { get; set; }
        
        [Required]
        public string Model { get; set; }
        
        [Required]
        [Range(1, 500)]
        public decimal WeightLimit { get; set; }
        
        [Required]
        [Range(0, 100)]
        public decimal BatteryCapacity { get; set; }
        
        [Required]
        public string State { get; set; }
    }
    
    public class CreateDroneResponse
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }   
    }
}