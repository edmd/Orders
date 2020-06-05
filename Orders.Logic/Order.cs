
namespace Orders.Logic
{
    #region Order...

    public class Order : IOrder
    {
        public double Price { get; set; }
        public int Size { get; set; }
        public string Symbol { get; set; }

        // Domain instance should encapsulate it's own logic
        public override string ToString()
        {
            return string.Format($"Size:\t{Size}\tSymbol:\t{Symbol}\tPrice:\t{Price}");
        }
    }

    #endregion
}
