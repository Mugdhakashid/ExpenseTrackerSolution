using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Services.Interfaces;
using Models;

namespace ExpenseTracker.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ExpenseTrackerDbContext _db;

        public CategoryService(ExpenseTrackerDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Models.Category>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Models.Category?> GetByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<Models.Category> CreateAsync(Models.Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> UpdateAsync(Models.Category category)
        {
            var exists = await _db.Categories.AnyAsync(c => c.Id == category.Id);
            if (!exists) return false;
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Categories.FindAsync(id);
            if (entity == null) return false;
            _db.Categories.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
