using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Logic
{
    #region Order Repository...

    /// <summary>
    /// We are only performing read functions in this project: 
    /// this class will be instantiated with the readonly (replication) connectionstring
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        //public DbReadOnlyOrderRepository(IConfig config) { };

        // TODO: Reduce DataStore reads by caching the retrieved orders
        public async Task<IEnumerable<IOrder>> GetItems()
        {
            try
            {
                return await Task.FromResult(new List<Order>());
            } catch(Exception ex)
            {
                // TODO: Log the error to the configured output
            }

            return null;
        }
    }

    #endregion
}