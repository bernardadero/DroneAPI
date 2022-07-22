using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DroneAPI.Database;
using DroneAPI.Utilities;
using System;
using DroneAPI.Database.Impl;
using DroneAPI.Database.Interfaces;
using DroneAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DroneAPIContext>(options =>
  options.UseInMemoryDatabase("TestDataBase"));
//options.UseSqlServer(builder.Configuration.GetConnectionString("DroneAPIContext") ?? throw new InvalidOperationException("Connection string 'DroneAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDroneRepository, DroneRepository>();
builder.Services.AddScoped<IDroneService, DroneService>();

builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddScoped<IMEdicationService, MedicationService>();

builder.Services.AddScoped<IDroneBatteryepository, DroneBatteryRepository>();
builder.Services.AddScoped<IDroneBatteryService, DroneBatteryService>();

builder.Services.AddScoped<ILoadedMediceneRepository, LoadedMediceneRepository>();
builder.Services.AddScoped<ILoadedMedicineService, LoadMedicineService>();

builder.Services.AddScoped<CheckDroneBattries>();

//builder.Services.

var app = builder.Build();
var cts = new CancellationTokenSource();
using (var scope = app.Services.CreateScope())
{
     CheckDroneBattries chkBattreies = scope.ServiceProvider.GetRequiredService(typeof(CheckDroneBattries)) as CheckDroneBattries;
    chkBattreies.PeriodicallyCheckDroneBattries(30, cts.Token);
}
//app.Services.CreateScope






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
//CheckDroneBattries.PeriodicallyCheckDroneBattries(() => Console.WriteLine("Hello again!"), 4, cts.Token);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
