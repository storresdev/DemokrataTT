using DemokrataTT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemokrataTT.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Inicialización de datos
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Orfelina",
                    SecondName = "Maria",
                    LastName = "Sanchez",
                    SecondSurName = "Rueda",
                    BirdDate = new DateTime(1922, 11, 06),
                    Salary = 100,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Olegario",
                    SecondName = "Jose",
                    LastName = "Ceron",
                    SecondSurName = "Camacho",
                    BirdDate = new DateTime(1910, 01, 15),
                    Salary = 100,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                }
                );
        }
    }
}
