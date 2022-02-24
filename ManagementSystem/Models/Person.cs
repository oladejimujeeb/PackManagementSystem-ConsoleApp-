using System;

namespace ManagementSystem.Models
{
    public abstract  class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string email { get; set; }
        public DateTime Dob{ get; set; }
        public string Address { get; set; }
        public string Phonenumber{ get; set; }
    }

}