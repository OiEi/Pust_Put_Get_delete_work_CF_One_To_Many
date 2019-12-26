
using System.Data.Entity;


namespace EmplDataAcces
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("EmployeeDB")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        /*public DbSet<EmployeePasport> Pasports { get; set; }*/



    }
}
