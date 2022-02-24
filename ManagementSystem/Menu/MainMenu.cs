using System;
using ManagementSystem.Respository;

namespace ManagementSystem.Menu
{
    public class MainMenu
    {
        
        public void Appmenu()
        {
            ApplicationContext context = new ApplicationContext();
            DriverRespository driverRespository = new DriverRespository(context);
            Login login = new Login(context);
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Enter 1 To Login as Admin \nEnter 2 for Driver's registration\nEnter 3 to Login\nEnter any other number to exit");
                Console.Write("Enter choice:");
                Console.ForegroundColor = ConsoleColor.White;
                int choice = int.Parse(Console.ReadLine());
                if (choice < 4)
                {
                    switch (choice)
                    {
                        case 1:
                            login.AdminLogin();
                            break;
                        case 2:
                            driverRespository.DriverRegistration();
                            break;
                        case 3:
                            login.SignUp();
                            break;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Goodbye");
                    break;
                }
            }
            
        }
        
    }
    
}