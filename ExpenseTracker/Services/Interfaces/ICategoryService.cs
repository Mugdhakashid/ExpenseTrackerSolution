using Models;
using Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO?> GetByIdAsync(int id);
        Task<CategoryDTO> CreateAsync(CategoryDTO category);
        Task<bool> UpdateAsync(CategoryDTO category);
        Task<bool> DeleteAsync(int id);
    }
}
