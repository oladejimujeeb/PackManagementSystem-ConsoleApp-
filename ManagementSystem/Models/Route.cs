using System.Collections.Generic;

namespace ManagementSystem.Models
{
    public class Route
    {
        public int Id{ get; set; }
        public int Name{ get; set; }
        public virtual List<ParkRoute> ParkRoutes { get; set; } = new List<ParkRoute>();
    }
}