using DroneAPI.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DroneAPI.Models
{
    public class LoadedMedicineModel
    {
        public int Id { get; set; }

        public DateTime DateTimeLoaded { get; set; }

        // Foreign key   
        [Display(Name = "Drone")]
        public virtual int DroneId { get; set; }

        [ForeignKey("DroneId")]
        public virtual Drone Drone { get; set; }

        // Foreign key   
        [Display(Name = "MedicationModel")]
        public virtual int medicationId { get; set; }

        [ForeignKey("medicationId")]
      // [CustomValidation(typeof(DroneWeightLimitValidation), nameof(DroneWeightLimitValidation.DroneLoadedWeight(LoadedMedicineModel)))]
        public virtual MedicationModel MedicationModel { get; set; }

    }
}

