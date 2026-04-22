using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Services.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<Models.ExpenseTracker>> GetAllAsync();
        Task<Models.ExpenseTracker?> GetByIdAsync(int id);
        Task<Models.ExpenseTracker> CreateAsync(Models.ExpenseTracker expense);
        Task<bool> UpdateAsync(Models.ExpenseTracker expense);
        Task<bool> DeleteAsync(int id);
    }
}
