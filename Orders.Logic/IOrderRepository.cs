using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Logic
{
    public interface IOrderRepository
    {
        Task<IEnumerable<IOrder>> GetItems();
    }
}