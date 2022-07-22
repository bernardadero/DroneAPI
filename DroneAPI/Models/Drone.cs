using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DroneAPI.Utilities;

namespace DroneAPI.Models
{
    public enum DroneModelTypes
    {
        Lightweight,
        Middleweight,
        Cruiserweight,
        Heavyweight
    }
    
    public enum DroneState
    {
        IDLE,
        LOADING,
        LOADED,
        DELIVERING,
        DELIVERED,
        RETURNING
    }
    public class Drone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("SerialNumber", TypeName = "varchar(100)")]
        [MaxLength (100)]
        [Required(ErrorMessage = "Please enter serial number")]
        public string SerialNumber { get; set; }
        public DroneModelTypes Model { get; set; }

        //set limit to (500gr max);
        [Range(1, 500)]
        [Column("WeightLimit", TypeName = "decimal")]
        public decimal WeightLimit { get; set; }

        [Required]
        public decimal BatteryCapacity { get; set; }

        [Required]
        public DroneState State { get; set; }


    }
}
