using System;
using System.Threading.Tasks;

namespace ComparisonGenerator.DataAccess
{
    public interface IComparandSource
    {
        Task<string> GetComparand();
    }
}