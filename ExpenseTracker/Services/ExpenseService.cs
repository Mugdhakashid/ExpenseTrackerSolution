using ExpenseTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
namespace ExpenseTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ExpenseTrackerDbContext _db;

        public ExpenseService(ExpenseTrackerDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Models.ExpenseTracker>> GetAllAsync()
        {
            return await _db.Expenses.Include(e => e.Category).ToListAsync();
        }

        public async Task<Models.ExpenseTracker?> GetByIdAsync(int id)
        {
            return await _db.Expenses.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Models.ExpenseTracker> CreateAsync(Models.ExpenseTracker expense)
        {
            _db.Expenses.Add(expense);
            await _db.SaveChangesAsync();
            return expense;
        }

        public async Task<bool> UpdateAsync(Models.ExpenseTracker expense)
        {
            var exists = await _db.Expenses.AnyAsync(e => e.Id == expense.Id);
            if (!exists) return false;
            _db.Expenses.Update(expense);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Expenses.FindAsync(id);
            if (entity == null) return false;
            _db.Expenses.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
