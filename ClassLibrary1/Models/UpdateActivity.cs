using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UpdateActivity
    {
        //public string? VehicleName { get; set; }
        public UpdateActivity()
        {
            Activities = new List<MaintenanceActivity>();
        }
        public List<MaintenanceActivity> Activities { get; set; }
    }

}
