using System;
using System.Linq;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Respository
{
    public class PaymentRepository
    {
        private ApplicationContext _context;
        public int Id { get; set; }
        public int MotorId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public  Motor Motor { get; set; }
        public PaymentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void MakePayment(string id)
        {
            var selectMotor = _context.Motors.Where(x => x.DriverId == id);
            foreach (var item in selectMotor)
            {
                Console.WriteLine($"Car Id: {item.Id}\tCar name:{item.Carname}\tCar Registration Id:{item.CarReg}");
            }
            Console.Write("Enter the Car Id:");
            var carId = Convert.ToInt32(Console.ReadLine());
            var check = _context.Motors.Include(p=>p.Park).FirstOrDefault(x=>x.Id==carId);
            if (check!=null)
            {
                Console.Write("How many days payment:");
                int days = Convert.ToInt32(Console.ReadLine());
                var payDay = DateTime.Now.Date;
                var endDate = DateTime.Today.AddDays(days);
                var amount = check.NoOfSeater * check.Park.Price * days;
                Console.WriteLine($"******Payment details*******\nYou about to make payment for {days} days");
                Console.WriteLine($"You are charged #{check.Park.Price} per your motor seat, Your car seat is:{check.NoOfSeater} ");
                Console.WriteLine($"Your are paying for {days}days\nTotal Amount payable is #{amount}");
                Console.WriteLine("Enter 1 to make Payment\nEnter 2 to Decline");
                var choice = Convert.ToInt32(Console.ReadLine());
                if (choice < 2)
                {
                    var getCarRegistration = _context.Motors.Find(carId);
                    var carReg = getCarRegistration.CarReg;
                    for (int day = 1; day <= days; day++)
                    {
                        var amountPerday = check.NoOfSeater * check.Park.Price * day;
                        var date = DateTime.Today.AddDays(day);
                        var payment = new Payment(){MotorId =carReg , Amount = amountPerday,PaymentDate = payDay, ExpiryDate = date};
                        _context.Payments.Add(payment);
                        _context.SaveChanges();
                    }
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"Payment Confirmed!!\n payment for Car Id:{carReg}\tAmount:{amount}\tPayment Date{payDay}\nPayment End:{endDate}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Payment declined!!");
                    Console.ForegroundColor = ConsoleColor.White;//return;
                }
            }
        }

        public void ConfirmPayment()
        {
            Console.Write("Enter Car Registration Number:");
            var carReg = Console.ReadLine();
            var find = _context.Payments.Where(x=>x.MotorId==carReg).ToList();
            if (find!=null)
            {
                //var confirm = _context.Payments.Where(x => x.MotorId == carReg);
                foreach (var payment in find)
                {
                    var divName = _context.Motors.Include(x=>x.Driver).FirstOrDefault(x=>x.CarReg==carReg);
                    if (divName != null)
                        Console.WriteLine(
                            $"Driver Registration Id:{divName.DriverId} Motor Id:{payment.MotorId}\tPayment Date:{payment.PaymentDate}\tPayment Expiry Date:{payment.ExpiryDate}");
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Payment not found");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }
    }
}