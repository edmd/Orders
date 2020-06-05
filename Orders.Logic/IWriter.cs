using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Logic
{
    /// <summary>
    /// IWriter is a good candidate for generics
    /// </summary>
    public interface IWriter<T>
    {
        Task<int> Output(IEnumerable<T> items);
    }
}