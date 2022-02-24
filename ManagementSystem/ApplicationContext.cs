using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Driver>Drivers { get; set; }
        public DbSet<Staff>Staffs{ get; set; }
        public DbSet<Route>Route { get; set; }
        public DbSet<Park>Parks{ get; set; }
        public DbSet<ParkRoute>ParkRoutes { get; set; }
        public DbSet<Motor>Motors { get; set; }
        public DbSet<Admin>Admins { get; set; }
        public DbSet<Payment>Payments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user=root;database=ManagementSystem;port=3306;password=oladejimujib@gmail.com");
        }

    }
}