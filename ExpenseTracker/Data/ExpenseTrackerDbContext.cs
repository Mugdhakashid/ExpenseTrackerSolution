using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class ExpenseTrackerDbContext : DbContext
    {
        public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<ExpenseTracker> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
