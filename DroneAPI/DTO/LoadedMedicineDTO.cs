using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DroneAPI.Models;
using DroneAPI.Utilities;

namespace DroneAPI.DTO;

public class LoadedMedicineRequest
{
    public class CreateLoadedMedicineRequestDroneRequest
    {     
        [Required]
        public int DroneId { get; set; }
        
        public int medicationId { get; set; }
        
    }
    
    public class LoadedMedicineResponse
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }   
    }
}