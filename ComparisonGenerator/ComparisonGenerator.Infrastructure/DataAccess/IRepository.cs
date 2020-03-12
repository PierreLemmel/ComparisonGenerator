using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComparisonGenerator.Infrastructure.DataAccess
{
    public interface IRepository<TModel>
    {
        Task Add(TModel elt);
        Task<IReadOnlyCollection<TModel>> Get();
    }
}