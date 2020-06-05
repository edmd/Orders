using System;
using System.Collections.Generic;

namespace Orders.Logic
{
    public class DataGenerator
    {
        public static IEnumerable<IOrder> GetOrders()
        {
            var orders = new List<Order>();

            // 10 "small" order sizes
            for (int i = 0; i < 10; i++)
            {
                orders.Add(new Order
                {
                    Price = Math.Round((double)new Random().Next(0, 1000), 2),
                    Size = new Random().Next(1, 10),
                    Symbol = GetRandomCharacter(new Random()).ToString()
                });
            }

            // 10 "large" order sizes
            for (int i = 0; i < 10; i++)
            {
                orders.Add(new Order
                {
                    Price = Math.Round((double)new Random().Next(0, 1000), 2),
                    Size = new Random().Next(11, 100),
                    Symbol = GetRandomCharacter(new Random()).ToString()
                });
            }

            // 10 "other" order sizes
            for (int i = 0; i < 10; i++)
            {
                orders.Add(new Order
                {
                    Price = Math.Round((double)new Random().Next(0, 1000), 2),
                    Size = new Random().Next(101, 10000),
                    Symbol = GetRandomCharacter(new Random()).ToString()
                });
            }

            return orders;
        }

        private static char GetRandomCharacter(Random rng)
        {
            var characters = "£$€R";
            int index = rng.Next(characters.Length);
            return characters[index];
        }
    }
}
