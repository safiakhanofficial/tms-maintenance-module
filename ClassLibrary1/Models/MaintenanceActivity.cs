using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MaintenanceActivity
    {
        [Key]
        public int MaintenanceActivityId { get; set; }
        public int VehicleId { get; set; }
        public string MaintenanceType { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
