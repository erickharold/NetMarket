using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ClaseBase
    {
        private readonly MarketDbContext _context;

        public GenericRepository(MarketDbContext context )
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
           //throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
            //throw new NotImplementedException();
        }


        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecifications<T> specifications)
        {
            //throw new NotImplementedException();
            return await ApplySpecification(specifications).ToListAsync();
        }


        public async Task<T> GetByIdWithSpec(ISpecifications<T> specifications)
        {
            return await ApplySpecification(specifications).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecifications<T> specifications)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specifications);
        }

        public async Task<int> CountAsync(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
    }
}
