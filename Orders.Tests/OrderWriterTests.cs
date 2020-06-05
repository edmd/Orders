using NUnit.Framework;
using Orders.Logic;
using System.Linq;

namespace Orders.Tests
{
    public class OrderWriterTests
    {
        private ConsoleWriter<IOrder> _consoleWriter;

        [Test(), Category("Unit")]
        public void OrderWriterSuccess()
        {
            _consoleWriter = new ConsoleWriter<IOrder>();

            Assert.IsTrue(_consoleWriter.Output(DataGenerator.GetOrders().Where(o => o.Size <= (int)OrderSize.AnySize).OrderBy(o => o.Price)).Result == 30,
                "The number of Order results is not equal to the number that should be returned {30}.");
        }

        [Test]
        public void OrderWriterFailure()
        {
            _consoleWriter = new ConsoleWriter<IOrder>();

            Assert.IsTrue(_consoleWriter.Output(DataGenerator.GetOrders().Where(o => o.Size <= (int)OrderSize.InvalidSize).OrderBy(o => o.Price)).Result == 0,
                "The number of Order results is not equal to the number that should be returned {0}.");
        }

        [Test]
        public void OrderWriterSmallOrders()
        {
            _consoleWriter = new ConsoleWriter<IOrder>();

            Assert.IsTrue(_consoleWriter.Output(DataGenerator.GetOrders().Where(o => o.Size <= (int)OrderSize.SmallOrder).OrderBy(o => o.Price)).Result == 10,
                "The number of Order results is not equal to the number that should be returned {10}.");
        }

        [Test]
        public void OrderWriterLargeOrders()
        {
            _consoleWriter = new ConsoleWriter<IOrder>();

            Assert.IsTrue(_consoleWriter.Output(DataGenerator.GetOrders().Where(o => o.Size <= (int)OrderSize.LargeOrder).OrderBy(o => o.Price)).Result == 20,
                "The number of Order results is not equal to the number that should be returned {10}.");
        }
    }
}
