using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DroneAPI.Models;
using DroneAPI.Utilities;

namespace DroneAPI.DTO;

public class DroneBatteryRequest
{
    public class CreateDroneBatteryRequest
    {
      
        [Required]
        public int DroneId { get; set; }
        
        [Required]
        [Range(0, 100)]
        public decimal CurrentBatteryLevel { get; set; }
        
        [Required]
        public DateTime LogTime { get; set; } = DateTime.Now;
    }
    
    public class CreateDroneBatteryResponse
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }   
    }
}