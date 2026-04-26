using System.Collections.Generic;
using System.Threading.Tasks;
using Models.DTOs;

namespace ExpenseTracker.Services.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseDTO>> GetAllAsync();
        Task<ExpenseDTO?> GetByIdAsync(int id);
        Task<ExpenseDTO> CreateAsync(ExpenseDTO expense);
        Task<bool> UpdateAsync(ExpenseDTO expense);
        Task<bool> DeleteAsync(int id);
    }
}
