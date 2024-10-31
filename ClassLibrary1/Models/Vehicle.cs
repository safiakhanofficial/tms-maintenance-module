using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public required string Name { get; set; }
        public ICollection<MaintenanceActivity>? MaintenanceActivities { get; set; }
    }
}
