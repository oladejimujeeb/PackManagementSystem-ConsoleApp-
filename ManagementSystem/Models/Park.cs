using System.Collections.Generic;

namespace ManagementSystem.Models
{
    
    public class Park
    {
        public int Id{ get; set; }
        public string Description{ get; set; }
        public int Price { get; set; }
        public virtual List<Staff> Staffs { get; set; } = new List<Staff>();
        public virtual List<Driver> Drivers { get; set; } = new List<Driver>();
        public virtual List<Motor> Motors { get; set; } = new List<Motor>();
        public virtual List<ParkRoute> ParkRoutes { get; set; } = new List<ParkRoute>();
        
    }
}