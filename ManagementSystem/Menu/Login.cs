using System;
using System.Linq;
using ManagementSystem.Respository;

namespace ManagementSystem.Menu
{
    public class Login
    {
        private ApplicationContext _context;

        public Login(ApplicationContext context)
        {
            _context = context;
        }

        public void AdminLogin()
        {
            StaffRepository staffRepository = new StaffRepository(_context);
            DriverRespository driverRespository = new DriverRespository(_context);
            var admin = new AdminRepository(_context);
            Console.Write("Enter your Email:");
            var email = Console.ReadLine();
            Console.Write("Enter your Password:");
            var password = Console.ReadLine();
            var loginCheck = _context.Admins.FirstOrDefault(x => x.email == email && x.Password == password);
            if (_context.Admins.Count() <= 5 && loginCheck != null)
            {
                while (true)
                {
                    Console.WriteLine("Enter 1 to Create Park\nEnter 2 to Register new Admin\nEnter 3 to Register new staff" +
                                      "\nEnter 4 to Delete staff\nEnter 5  to Delete Admin\nEnter 6  to Delete staff\nEnter 7 to logout");
                    Console.Write("Enter Choice:");
                    var choice = int.Parse(Console.ReadLine());
                    if(choice<7)
                    {
                        switch (choice)
                        {
                            case 1: 
                                ParkRepository parkRepository = new ParkRepository(_context);
                                parkRepository.RegisterPark();
                                break;
                            case 2:
                                admin.AdminRegistration();
                                break;
                            case 3:
                                staffRepository.StaffResgistration();
                                break;
                            case 4:
                                staffRepository.GetAllStaff();
                                staffRepository.DeleteStaff();
                                break;
                            case 5:
                                admin.DeleteAdmin();
                                break;
                            case 6:
                                driverRespository.DeleteDriver(); 
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong Username of Password");
            }
        }
        public void SignUp()
        {
            var paymentRepository = new PaymentRepository(_context);
            var motorRepo = new MotorRepository(_context);
            
            Console.Write("Enter your Registration number:");
            var loginDetail = Console.ReadLine();
            var check = loginDetail.Substring(0, 3);
            if (check.StartsWith("DRV"))
            {
                var confirmReg = _context.Drivers.Where(x=>x.RegtrationId==loginDetail);
                if (confirmReg !=null)
                {
                    var name = _context.Drivers.Where(x => x.RegtrationId == loginDetail).FirstOrDefault();
                    Console.WriteLine($"Welcome Mr.{name.Firstname}");
                    while (true)
                    {
                        Console.WriteLine("Enter 1 for Car registration\nEnter 2 to Make Today's payment\nEnter 3 to Logout");
                        Console.Write("Choice:");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice < 3)
                        {
                            switch (choice)
                            {
                                case 1:
                                    motorRepo.RegisterCar();
                                    break;
                                case 2:
                                    paymentRepository.MakePayment(loginDetail);
                                    break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            else if (check.StartsWith("NUR"))
            {
                var confirmReg = _context.Staffs.Where(x=>x.RegNum==loginDetail);
                if (confirmReg!=null)
                {
                    var name = _context.Staffs.Where(x => x.RegNum == loginDetail).FirstOrDefault();
                    Console.WriteLine($"Welcome Mr.{name.Firstname}");
                    
                    DriverRespository driverRespository = new DriverRespository(_context);
                    MotorRepository motorRepository = new MotorRepository(_context);
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Enter 1 to print Driver details\nEnter 2 to print All Driver");
                        Console.WriteLine("Enter 3 to search for a Driver\nEnter 4 to Confirm Payment");
                        Console.WriteLine("Enter 5 to search for a car");
                        Console.WriteLine("Enter any other number to logout");
                        Console.Write("Enter choice:");
                        Console.ForegroundColor = ConsoleColor.White;
                        int choice = int.Parse(Console.ReadLine());
                        if (choice < 6)
                        {
                            switch (choice)
                            {
                                case 1:
                                    driverRespository.GetCarByDriver();
                                    break;
                                case 2:
                                    driverRespository.GetAllDriver();
                                    break;
                                case 3:
                                    driverRespository.SeachDriver();
                                    break;
                                case 4:
                                    paymentRepository.ConfirmPayment();
                                    break;
                                case 5:
                                    motorRepository.SeachMotor();
                                    break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Username or Password");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}