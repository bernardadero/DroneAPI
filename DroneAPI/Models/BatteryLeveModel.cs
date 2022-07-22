using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DroneAPI.Models
{
    public class BatteryLeveModel
    {
        public int Id { get; set; }

        // Foreign key   
        [Display(Name = "Drone")]
        public virtual int DroneId { get; set; }

        [ForeignKey("DroneId")]
        public virtual Drone Drone { get; set; }
        public decimal CurrentBatteryLevel { get; set; }
        public DateTime LogTime { get; set; } = DateTime.Now;
    }
}
