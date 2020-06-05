using Moq;
using NUnit.Framework;
using Orders.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Tests
{
    public class OrderManagerTests
    {
        private OrderManager _orderManager;
        private Mock<IOrderRepository> _orderStoreMock;
        private Mock<IWriter<IOrder>> _orderWriterMock;

        [SetUp]
        public void Setup()
        {
            _orderStoreMock = new Mock<IOrderRepository>();
            _orderStoreMock.Setup(x => x.GetItems()).Returns(Task.FromResult(DataGenerator.GetOrders()));

            _orderWriterMock = new Mock<IWriter<IOrder>>();
            _orderWriterMock.Setup(x => x.Output(It.IsAny<IEnumerable<IOrder>>())).Returns(Task.FromResult(1));

            _orderManager = new OrderManager(_orderStoreMock.Object, _orderWriterMock.Object);
        }

        [Test(), Category("Unit")]
        public void OrderManagerSuccess()
        {
            Assert.IsTrue(_orderManager.OutputOrders().Result, "Result is false where OrderManager.OutputItems() is expected to be true.");
        }

        [Test(), Category("Unit")]
        public void OrderManagerStoreFail()
        {
            _orderManager = new OrderManager(null, _orderWriterMock.Object);

            Assert.IsFalse(_orderManager.OutputOrders().Result, "Result is true where OrderManager.OutputItems() is expected to be false.");
        }

        [Test(), Category("Unit")]
        public void OrderManagerWriterFail()
        {
            _orderManager = new OrderManager(_orderStoreMock.Object, null);

            Assert.IsFalse(_orderManager.OutputOrders().Result, "Result is true where OrderManager.OutputItems() is expected to be false.");
        }

        [Test(), Category("Integration")]
        public void OrderManagerIntSuccess()
        {
            _orderManager = new OrderManager(
                _orderStoreMock.Object, new ConsoleWriter<IOrder>()
            );

            Assert.IsTrue(_orderManager.OutputOrders().Result, "Result is false where OrderManager.OutputItems() is expected to be true.");
        }

        [Test(), Category("Integration")]
        public void OrderManagerIntAnySize()
        {
            _orderManager = new OrderManager(
                _orderStoreMock.Object, new ConsoleWriter<IOrder>()
            );

            Assert.IsTrue(_orderManager.OutputOrders((int)OrderSize.AnySize).Result, "Result is false where OrderManager.OutputItems() is expected to be true.");
        }

        [Test(), Category("Integration")]
        public void OrderManagerIntFailure()
        {
            _orderManager = new OrderManager(
                _orderStoreMock.Object, new ConsoleWriter<IOrder>()
            );

            Assert.IsFalse(_orderManager.OutputOrders((int)OrderSize.InvalidSize).Result, "Result is true where OrderManager.OutputItems() is expected to be false.");
        }

        [Test(), Category("Integration")]
        public void OrderManagerIntSmallOrders()
        {
            _orderManager = new OrderManager(
                _orderStoreMock.Object, new ConsoleWriter<IOrder>()
            );

            Assert.IsTrue(_orderManager.OutputOrders((int)OrderSize.SmallOrder).Result, "Result is false where OrderManager.OutputItems() is expected to be true.");
        }

        [Test(), Category("Integration")]
        public void OrderManagerIntLargeOrders()
        {
            _orderManager = new OrderManager(
                _orderStoreMock.Object, new ConsoleWriter<IOrder>()
            );

            Assert.IsTrue(_orderManager.OutputOrders((int)OrderSize.LargeOrder).Result, "Result is false where OrderManager.OutputItems() is expected to be true.");
        }
    }
}