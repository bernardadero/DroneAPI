using DroneAPI.Database;
using DroneAPI.Database.Interfaces;
using DroneAPI.Interfaces;
using DroneAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace DroneAPI.Utilities
{
    public class CheckDroneBattries
    {
        //periodic task to check drones battery 
        private IDroneBatteryepository _repository;
        private IDroneRepository _dronerepository;
        public CheckDroneBattries(IDroneBatteryepository repository, IDroneRepository dronerepository, ILoggerFactory logger)
        {
            _repository = repository;
            _dronerepository = dronerepository;
        }

       

        // Method to outomatically check and log drone battries level after ever 30 seconds
        internal void PeriodicallyCheckDroneBattries(int seconds, CancellationToken token)
{
           
            Task.Run(async () => {
                while (!token.IsCancellationRequested)
                {
                    UpdateBattryLevel();
                    await Task.Delay(TimeSpan.FromSeconds(seconds), token);
                }
            }, token);
        }
        public async Task UpdateBattryLevel()
        {

            var drones = _dronerepository.GetAll();
            foreach (var drone in drones)
            {
                var blvel = new BatteryLeveModel()
                {
                    DroneId = drone.Id,
                    CurrentBatteryLevel = drone.BatteryCapacity,
                    LogTime = DateTime.Now,
                };
                int id = _repository.Add(blvel);

            }
        }

    }
}
