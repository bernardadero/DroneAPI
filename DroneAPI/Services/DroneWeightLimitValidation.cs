using DroneAPI.Database;
using DroneAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DroneAPI.Utilities
{
    public class DroneWeightLimitValidation
    {
        //Drone validation checks
        private readonly DroneAPIContext _context;
        private readonly ILogger _logger;

        public DroneWeightLimitValidation()
        {
        }

        public DroneWeightLimitValidation(DroneAPIContext context, ILoggerFactory logger)
        {
            _logger = logger.CreateLogger("MyCategory");
            _context = context;
        }
        public static ValidationResult MaximumWeight(decimal weight)
        {
            return weight > 500 ? new ValidationResult("Weight can not exceed 500gr")
                : ValidationResult.Success;
        }

        internal  bool DroneLoadedWeight(LoadedMedicineModel loadedMedicineModel)
        {
        
            // get dron weight from droneId

            decimal medicineweight = _context.Drone
                        .Where(capacity => capacity.Id == loadedMedicineModel.medicationId)
                        .Select(capacity => capacity.BatteryCapacity)
                        .SingleOrDefault();
                  
            // get medicine weight from medication
            decimal dronelimit = _context.Drone
                        .Where(capacity => capacity.Id == loadedMedicineModel.DroneId)
                        .Select(capacity => capacity.BatteryCapacity)
                        .SingleOrDefault();

            return medicineweight > dronelimit ? false : true; 
        }
     

    }
}
    

