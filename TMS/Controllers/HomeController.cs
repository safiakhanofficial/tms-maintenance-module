using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TMS.Models;
using DAL;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using Newtonsoft.Json;

namespace TMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var maintenanceActivities = await _context.MaintenanceActivities
                .Include(m => m.Vehicle)
                .ToListAsync();

            var viewModel = new UpdateActivity
            {
                Activities = maintenanceActivities
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            try
            {
                var activities = await _context.MaintenanceActivities
                    .Include(a => a.Vehicle)
                    .Select(a => new MaintenanceActivity
                    {
                        MaintenanceActivityId = a.MaintenanceActivityId,
                        MaintenanceType = a.MaintenanceType,
                        Date = a.Date,
                        Description = a.Description,
                        Notes = a.Notes,
                        Vehicle= a.Vehicle
                    })
                    .ToListAsync();

                var viewModel = new UpdateActivity
                {
                    //VehicleName = Vehicle.Name,
                    Activities = activities
                };

                // return Json(new { success = true, message = "Activity updated successfully!" });
                return Json(new { data = activities });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddActivity([FromBody] UpdateActivity newActivity)
        {
            if (newActivity == null || newActivity.Activities == null || newActivity.Activities.Count == 0)
            {
                return BadRequest("Invalid activity data.");
            }

            var activityData = newActivity.Activities[0];

            if(activityData.Vehicle.Name != null)
            {
                var vehicle = new Vehicle
                {
                    Name = activityData.Vehicle.Name
                };
                _context.Vehicles.Add(vehicle);

                var activity = new MaintenanceActivity
                {
                    Vehicle = vehicle,
                    MaintenanceType = activityData.MaintenanceType,
                    Date = activityData.Date,
                    Description = activityData.Description,
                    Notes = activityData.Notes
                };

                _context.MaintenanceActivities.Add(activity);

                await _context.SaveChangesAsync();
            }
            return Ok(new { message = "Activity added successfully!" });
        }


        [HttpPut]
        public IActionResult Delete([FromBody] int id) 
        { 
            if (id == 0) return Json(new { Success=false, message="Activity Id not found!" });

            var existingActivity = _context.MaintenanceActivities.FirstOrDefault(a => a.MaintenanceActivityId == id);
            if (existingActivity == null)
            {
                return NotFound("Activity not found.");
            }
            _context.MaintenanceActivities.Remove(existingActivity);
            _context.SaveChanges();
            return Json(new { Success = true, message= "Activity deleted successfully!"});
        }   

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Update([FromBody] UpdateActivity model)
        {
            if (model == null || model.Activities == null || !model.Activities.Any())
            {
                return BadRequest("Invalid data.");
            }

            var updatedActivity = model.Activities.First();
            var existingActivity = _context.MaintenanceActivities
                .FirstOrDefault(a => a.MaintenanceActivityId == updatedActivity.MaintenanceActivityId);

            if (existingActivity == null)
            {
                return NotFound("Activity not found.");
            }

            if (updatedActivity.Vehicle == null)
            {
                return Json(new { success = false, message = "Vehicle not found!" });
            }

            // Update fields
            var vehicle = _context.Vehicles.FirstOrDefault(a => a.VehicleId == existingActivity.VehicleId);
            if (vehicle == null)
            {
                return Json(new { success = false, message = "Vehicle not found!" });
            }
            existingActivity.Vehicle.Name = updatedActivity.Vehicle.Name;
            existingActivity.MaintenanceType = updatedActivity.MaintenanceType;
            existingActivity.Description = updatedActivity.Description;
            existingActivity.Notes = updatedActivity.Notes;
            _context.SaveChanges();
            return Json(new { success = true, message = "Activity updated successfully!" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
