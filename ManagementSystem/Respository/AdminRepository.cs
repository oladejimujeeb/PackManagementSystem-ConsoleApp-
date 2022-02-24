using System;
using ManagementSystem.Models;

namespace ManagementSystem.Respository
{
    public class AdminRepository
    {
        private ApplicationContext _context;

        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AdminRegistration()
        {
            Console.Write("Enter your First name:");
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
            Console.Write("Enter your password:");
            var password = Console.ReadLine();
            Admin admin = new Admin()
            {
                Firstname = firstname, Lastname = lastname, Address = address,
                Dob = dob,  Phonenumber = phonenumber, email = email, Password =password
            };
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }

        public void DeleteAdmin()
        {
            Console.Write("Enter Admin ID:");
            var id = int.Parse(Console.ReadLine());
            var del= _context.Admins.Find(id);
            _context.Admins.Remove(del);
            _context.SaveChanges();
            Console.WriteLine("Successfully Deleted");
        }

        /*public void CreatePark()
        {
            Console.Write("Enter park Description:");
            string description = Console.ReadLine();
            var park = new Park(){Description = description };
            _context.Parks.Add(park);
            _context.SaveChanges();
        }*/
    }
    
}