using System;
using System.Collections;
using System.Linq;
using ManagementSystem.Models;

namespace ManagementSystem.Respository
{
    public class StaffRepository
    {
        private ApplicationContext _context;

        public StaffRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void StaffResgistration()
        {
            Console.Write("Enter your Fisrt name:");
            var firstname = Console.ReadLine();
            Console.Write("Enter your Last name:");
            var lastname = Console.ReadLine();
            Console.Write("Enter your Date of Birth yyyy/mm/dd:");
            DateTime dob = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Phone Number:");
            var phonenumber = Console.ReadLine();
            Console.Write("Enter Email:");
            var email = Console.ReadLine();
            Console.Write("Enter Address:");
            var address = Console.ReadLine();
            Console.Write("Enter Park:");
            var parkId = int.Parse(Console.ReadLine());
            var staff = new Staff()
            {
                Firstname = firstname, Lastname = lastname, Dob = dob.Date, Phonenumber = phonenumber, email = email,
                Address = address, RegNum = GenerateStaffId() , PackId = parkId
                
            };
            _context.Staffs.Add(staff);
            _context.SaveChanges();
            var confirmReg = _context.Staffs;
            foreach (var sta in confirmReg)
            {
                Console.WriteLine($"Registration Successful!!\t Your Registration Id is:{sta.RegNum}");  
            }
            
        }

        public string GenerateStaffId()
        {
            return $"NURT/{Guid.NewGuid().ToString().Substring(0, 3)}";
        }

        public void GetAllStaff()
        {
            var allStaff = _context.Staffs;
            foreach (var staff in allStaff)
            {
                Console.WriteLine($"Staff ID:{staff.Id}   Staff Name:{staff.Firstname} {staff.Lastname}");
            }
        }

        public void DeleteStaff()
        {
            Console.Write("Enter Staff Id:");
            int Id = int.Parse(Console.ReadLine());
            var delete = _context.Staffs.Find(Id);
            _context.Staffs.Remove(delete);
            _context.SaveChanges();
            Console.WriteLine("Deleted successfully");
        }
        
    }
}