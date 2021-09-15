using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoWithCategoriaAndMarca: BaseSpecification<Producto>
    {
        public ProductoWithCategoriaAndMarca()
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);
        }

        public ProductoWithCategoriaAndMarca(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);
        }
    }
}
