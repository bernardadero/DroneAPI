using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DroneAPI.Models;
using DroneAPI.Utilities;

namespace DroneAPI.DTO;

public class MedicationRequest
{
    public class CreateMedicationRequest
    {
        
        //allowe only letters, numbers, ‘-‘, ‘_’

        [RegularExpression(@"^[a-zA-Z0-9-_]+$")]
        [Column("Name", TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }

        [Column("WeightLimit", TypeName = "decimal")]
        public decimal Weight { get; set; }


        //allowe only upper case letters, underscore and numbers.
        [RegularExpression(@"^[A-Z0-9_]+$")]
        [Required]
        public string Code { get; set; }

        public byte[]? Image { get; set; }
    }
    
    public class CreateMedicationResponse
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }   
    }
}