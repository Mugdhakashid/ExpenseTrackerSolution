using ExpenseTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs;
namespace ExpenseTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ExpenseTrackerDbContext _db;

        public ExpenseService(ExpenseTrackerDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAllAsync()
        {
            var categories= await _db.Expenses.Include(e => e.Category).ToListAsync();
            return categories.Select(e => new ExpenseDTO
            {
                Id = e.Id,
                Title = e.Title,
                Amount = e.Amount,
                Date = e.Date,
                CategoryId = e.CategoryId,
                CategoryName = e.Category.Name
            });

        }

        public async Task<ExpenseDTO> GetByIdAsync(int id)
        {
            var category= await _db.Expenses.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
            if (category == null) return null;
            return new ExpenseDTO
            {
                Id = category.Id,
                Title = category.Title,
                Amount = category.Amount,
                Date = category.Date,
                CategoryId = category.CategoryId,
                CategoryName = category.Category.Name
            };
        }

        public async Task<ExpenseDTO> CreateAsync(ExpenseDTO expense)
        {
            Models.ExpenseTracker expenseTracker=new Models.ExpenseTracker
            {
                Title = expense.Title,
                Amount = expense.Amount,
                Date = expense.Date,
                CategoryId = expense.CategoryId
            };
            _db.Expenses.Add(expenseTracker);
            await _db.SaveChangesAsync();
            return expense;
        }

        public async Task<bool> UpdateAsync(ExpenseDTO expense)
        {
            Models.ExpenseTracker expenseTracker = new Models.ExpenseTracker
            {
                Title = expense.Title,
                Amount = expense.Amount,
                Date = expense.Date,
                CategoryId = expense.CategoryId
            };
            _db.Expenses.Update(expenseTracker);
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
