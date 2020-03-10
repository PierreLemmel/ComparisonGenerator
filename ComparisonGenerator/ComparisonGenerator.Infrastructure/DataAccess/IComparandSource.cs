using System;
using System.Threading.Tasks;

namespace ComparisonGenerator.Infrastructure.DataAccess
{
    public interface IComparandSource
    {
        Task<string> GetComparand();
    }
}