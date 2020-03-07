using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComparisonGenerator.DataAccess
{
    public interface IRepository<TModel>
    {
        Task Add(TModel elt);
        Task<IEnumerable<TModel>> Get();
    }
}