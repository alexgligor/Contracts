using Microsoft.EntityFrameworkCore;

namespace Contracts.Models.SQL
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<FinancialInfo> FinancialInfo { get; set; }

        public DataBaseContext(DbContextOptions opt) : base(opt)
        {
            
        }
    }
}