using System.Collections.Generic;

namespace ManagementSystem.Models
{
    public class Driver:Person
    {
        public int Id{ get; set; }
        public string RegtrationId{ get; set; }
        public int ParkId { get; set; }
        public string DrivingLicense{ get; set; }
        public Park Park { get; set; }
        public virtual List<Motor> Motors { get; set; } = new List<Motor>();
    }
}