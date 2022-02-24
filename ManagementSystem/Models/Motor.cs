using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Models
{
    public class Motor
    {
        public int Id { get; set; }
        public string Carname { get; set; }
        public CarType CarType{ get; set; }
        public int NoOfSeater { get; set; }
        public string CarReg { get; set; }
        public string DriverId { get; set; }
        public int ParkId { get; set; }
        public Park Park { get; set; }
        
        public Driver Driver { get; set; }

        public virtual List<Payment> Payments { get; set; } = new List<Payment>();

        //public Dictionary<DateTime,bool> Calendar { get; set; }
    }
   
}