using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Logic
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MarketDbContext _context;

        public ProductoRepository(MarketDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Producto>> GetProductoAsync()
        {
            return await _context.Producto
                                .Include(p => p.Marca)
                                .Include(p => p.Categoria)
                                .ToListAsync();
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Producto
                                 .Include(p => p.Marca)
                                 .Include(p => p.Categoria)
                                 .FirstOrDefaultAsync(p => p.Id == id);
            //FindAsync(id);

            //COMNETANDO FIN
        }
    }
}
