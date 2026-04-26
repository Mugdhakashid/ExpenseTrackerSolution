using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Services.Interfaces;
using Models.DTOs;
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

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categories= await _db.Categories.ToListAsync();
            return categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var category= await _db.Categories.FindAsync(id);
            if (category == null) return null;
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task<CategoryDTO> CreateAsync(CategoryDTO dto)
        {
            Category categoryEntity = new Category
            {
                Id = dto.Id,
                Name = dto.Name
            };
            _db.Categories.Add(categoryEntity);
            await _db.SaveChangesAsync();

           
            return  dto;
        }

        public async Task<bool> UpdateAsync(CategoryDTO dto)
        {
            Category categoryEntity = new Category
            {
                Id = dto.Id,
                Name = dto.Name
            };
            _db.Categories.Update(categoryEntity);
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
