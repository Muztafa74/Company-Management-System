using Microsoft.EntityFrameworkCore;

namespace Company.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MUSTAFA;Database=Company;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Emp_project> Emp_Projects { get; set; }

    }
}
