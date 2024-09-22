using Microsoft.AspNetCore.Mvc;
using Planificalo.Shared.Responses;

namespace Planificalo.Backend.UnitsOfWork.Interfaces
{
    public interface IGenericUnitOfWork<T> where T : class
    {
        Task<ActionResponse<IEnumerable<T>>> GetAllAsync();

        Task<ActionResponse<T>> GetByIdAsync(int id);

        Task<ActionResponse<T>> AddAsync(T entity);

        Task<ActionResponse<T>> UpdateAsync(T entity);

        Task<ActionResponse<T>> DeleteAsync(int id);
    }
}