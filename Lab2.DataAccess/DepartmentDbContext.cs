using Microsoft.EntityFrameworkCore;

namespace Lab2.DataAccess
{
    public class DepartmentDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DepartmentDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\austr\\source\\repos\\Lab2.DataAccess\\Lab2.DataAccess\\DepartmentDb.mdf;Integrated Security=True");

    }
}
