using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Logic
{
    #region Order...

    public interface IOrder
    {
        double Price { get; set; }
        int Size { get; set; }
        string Symbol { get; set; }
    }

    #endregion
}