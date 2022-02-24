using System;

namespace ManagementSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string MotorId { get; set; }
        public DateTime ExpiryDate{ get; set; }
        public DateTime PaymentDate { get; set; }
        public int Amount { get; set; }
        public  Motor Motor { get; set; }
    }
}