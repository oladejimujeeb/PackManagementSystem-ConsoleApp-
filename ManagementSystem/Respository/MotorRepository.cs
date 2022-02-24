using System;
using System.Linq;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Respository
{
    public class MotorRepository
    {
        private ApplicationContext _context;

        public MotorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void RegisterCar()
        {
            Console.Write("Enter your vehicle name:");
            var carname = Console.ReadLine();
            Console.Write("Enter number of seat:");
            var noofSeat = int.Parse(Console.ReadLine());
            Console.Write("Enter your Registration Id:");
            string driverId = Console.ReadLine();
            string carReg = GenerateVehicleId();
            var park = _context.Parks;
            foreach (var item in park)
            {
                Console.WriteLine($"{item.Id}\t{item.Description}\tPark Charges: {item.Price}" );
            }
            Console.Write("Enter the Park you want to register to:");
            int parkId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your car type:");
            Console.WriteLine("Enter 1 for Car\nEnter 2 for Minibus\nEnter 3 for Bus");
            var cartype = (CarType)int.Parse(Console.ReadLine());
            var motors = new Motor() {Carname =carname,NoOfSeater =noofSeat,DriverId  = driverId, ParkId=parkId, CarType = cartype, CarReg = carReg};
            _context.Motors.Add(motors);
            _context.SaveChanges();
            Console.WriteLine($"Created Successfully\nYour car registration number is {carReg}");
        }
        public string GenerateVehicleId()
        {
            return $"NRG/{Guid.NewGuid().ToString().Substring(0, 4)}";
        }
        public void SeachMotor()
        {
            Console.Write("Enter the Enter Car Registration Number :");
            var carId = Console.ReadLine();
            var drivers = _context.Motors.FirstOrDefault(x=>x.CarReg==carId);
            if (drivers==null)
            {
                Console.WriteLine($"Car with ID:{carId}, not found");
            }

            var driver = _context.Motors.Include(x=>x.Park).Where(x => x.CarReg == carId);
            foreach (var field in driver)
            {
                Console.WriteLine($"Car Name:{field.Carname}\tDriver Pack:{field.Park.Description}\tDriver Id:{field.DriverId}\tNo of Seat:{field.NoOfSeater}");
            }
        }
        

    }
}