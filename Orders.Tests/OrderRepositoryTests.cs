using NUnit.Framework;
using Orders.Logic;

namespace Orders.Tests
{
    public class OrderRepositoryTests
    {
        private IOrderRepository _orderRepository;

        [SetUp]
        public void Setup()
        {
            _orderRepository = new OrderRepository();
        }

        [Test, Category("Unit")]
        public void OrderRepositorySuccess()
        {
            Assert.IsNotNull(_orderRepository.GetItems(), 
                "A result from the repository was not returned where one was expected.");
        }
    }
}