using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Logic
{
    public interface IManager
    {
        Task<bool> OutputOrders(int filterSize);
    }

    public class OrderManager : IManager
    {
        private readonly IOrderRepository _repository;
        private readonly IWriter<IOrder> _writer;

        public OrderManager(IOrderRepository repository, IWriter<IOrder> writer)
        {
            _repository = repository;
            _writer = writer;
        }

        public Task<bool> OutputOrders(int filterSize = (int)OrderSize.AnySize)
        {
            try
            {
                return _writer.Output(FilterOrdersBySize(filterSize)).Result > 0 ?
                    Task.FromResult(true) :
                    Task.FromResult(false);
            }
            catch (Exception ex)
            {
                // TODO: Log the error to the configured output
                return Task.FromResult(false);
            }
        }

        /// <summary>
        /// FilterOrdersBySize can be called from various methods - not just OutputItems
        /// </summary>
        private IEnumerable<IOrder> FilterOrdersBySize(int filterSize = (int)OrderSize.AnySize)
        {
            return _repository.GetItems().Result.Where(o => o.Size <= filterSize).OrderBy(o => o.Price);
        }
    }
}