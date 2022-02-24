using System;
using System.Linq;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Respository
{
    public class DriverRespository
    {
        private ApplicationContext _context;

        public DriverRespository(ApplicationContext context)
        {
            _context = context;
        }

        public void DriverRegistration()
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
            Console.Write("Enter Drivers License:");
            var driverLicense = Console.ReadLine();
            string registrationId = GenerateDriverId();
            var driver = new Driver()
            {
                Firstname = firstname, Lastname = lastname, Dob = dob.Date, Phonenumber = phonenumber, email = email,
                Address = address, ParkId = parkId, DrivingLicense = driverLicense, RegtrationId = registrationId
            };
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            
            //DRV/8ea044
            Console.WriteLine($"Registration Successful!!\nYour Login detail is Registration Id:{registrationId}");
        }
        public string GenerateDriverId()
        {
            return $"DRV/{Guid.NewGuid().ToString().Substring(0, 6)}";
        }

        public void SeachDriver()
        {
            Console.Write("Enter the Driver Registration Number :");
            var driverId = Console.ReadLine();
            var drivers = _context.Drivers.FirstOrDefault(x=>x.RegtrationId==driverId);
            if (drivers==null)
            {
                Console.WriteLine($"Driver with{driverId}not found");
            }

            var driver = _context.Drivers.Include(x=>x.Park).Where(x => x.RegtrationId == driverId);
            foreach (var field in driver)
            {
                Console.WriteLine($"Driver Name:{field.Firstname} {field.Lastname}\tDriver Park:{field.Park.Description}\nDriver Phone:{field.Phonenumber}\tDriver Adress{field.Address}");
            }
        }

        public void GetAllDriver()
        {
            var Driver = _context.Drivers.Include(x=>x.Park);
            foreach (var drivers in Driver)
            {
                Console.WriteLine($"Name:{drivers.Firstname} Park:{drivers.Park.Description} Driver Id:{drivers.RegtrationId} Address:{drivers.Address} Phonenumber:{drivers.Phonenumber}");
            }
        }

        public void GetCarByDriver()
        {
            Console.Write("Enter Driver's Registration Number:");
            var divReg = Console.ReadLine();
            var divCar = _context.Motors.Include(x=>x.Park).FirstOrDefault(x=>x.DriverId==divReg);
            if (divCar == null)
            {
                Console.WriteLine($"Driver with Registration number {divReg} not found");
            }

            else
            {
                var drivers = _context.Drivers.Where(x => x.RegtrationId == divReg);
                foreach (var div in drivers)
                {
                    Console.WriteLine($"Name:{div.Firstname}\t{div.Lastname}\tDriver Park:{div.Park.Description}\tRegistration Number:{div.RegtrationId}\tCar Type:{divCar.Carname}\tNo of Seater:{divCar.NoOfSeater}\n Car registration number:{divCar.CarReg}");
                }
            }
        }
        public void DeleteDriver()
        {
            Console.Write("Enter Driver Registration no:");
            var id = Console.ReadLine();
            var del= _context.Drivers.FirstOrDefault(x=>x.RegtrationId==id);
            _context.Drivers.Remove(del);
            _context.SaveChanges();
            Console.WriteLine("Successfully Deleted");
        }
    }
}