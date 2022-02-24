using System;
using ManagementSystem.Models;

namespace ManagementSystem.Respository
{
    public class ParkRepository
    {
        private readonly ApplicationContext _context;

        public ParkRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void RegisterPark()
        {
            Console.Write("Enter the name and Description of the Park:");
            var desc = Console.ReadLine();
            Console.Write("Enter Park Charges:");
            var charges = Convert.ToInt32(Console.ReadLine());
            Park park = new Park
            {
                Description = desc, Price = charges,
            };
            _context.Parks.Add(park);
            _context.SaveChanges();
            Console.WriteLine("Park Created Successfully");
        }
    }
}