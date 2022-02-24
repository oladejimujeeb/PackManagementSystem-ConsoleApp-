namespace ManagementSystem.Models
{
    public class ParkRoute
    {
        public int Id { get; set; }
        public int ParkId { get; set; }
        public int RouteId{ get; set; }
        public Route Route{ get; set; }
        public Park Park{ get; set; }
    }
}