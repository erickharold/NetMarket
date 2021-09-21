using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository <T> where T : ClaseBase
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdWithSpec(ISpecifications<T> specifications);
        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecifications<T> specifications);
        Task<int> CountAsync(ISpecifications<T> spec);
    }
}
