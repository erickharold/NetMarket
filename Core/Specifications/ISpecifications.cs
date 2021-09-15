using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecifications<T>
    {

        //LA CRITERIA CONDICIONA UNA EXPRESION LOGICA A LA TABLA Q VAMOS A EMPLEAR
        Expression<Func<T, bool>> Criteria { get; }

        //LAS RELACIONES Q SE VA IMPLEMENTAR EN LA ENTIDAD
        List<Expression<Func<T, object>>> Includes { get; }


    }
}
