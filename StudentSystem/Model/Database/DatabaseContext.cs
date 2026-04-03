using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace StudentSystem.Model.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string databaseFile = "Welcome.db";
            //string databasePath = Path.Combine(solutionFolder, databaseFile);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=VELIZARA\\SQLEXPRESS;Database=WelcomeStudentSystemDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(e => e.Id).ValueGeneratedOnAdd();

            var user = new User()
            {
                Id = 1,
                Names = "John Doe",
                Password = "password123",
                Email = "johndoe@gmail.com",
                Role = Others.UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10),
            };

            modelBuilder.Entity<User>().HasData(user);
        }
    }
}
