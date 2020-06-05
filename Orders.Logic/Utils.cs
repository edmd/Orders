using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Logic
{
    public enum OrderSize
    {
        SmallOrder = 10,
        LargeOrder = 100,
        AnySize = int.MaxValue,
        InvalidSize = int.MinValue
    }
}
