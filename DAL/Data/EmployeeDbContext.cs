using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSeeding((context, _) =>
            {
                context.Set<Position>().Add(new Position { Name = "Trainee" });
                context.Set<Position>().Add(new Position { Name = "Software Engineer" });
                context.Set<Position>().Add(new Position { Name = "Lead" });
                context.Set<Position>().Add(new Position { Name = "Manager" });
                context.SaveChanges();
            });

            base.OnConfiguring(optionsBuilder);
        }
    }
}
