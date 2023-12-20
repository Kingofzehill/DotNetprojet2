using StackExchange.Redis;
using System.Collections;
using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    /// <summary>
    /// The class that manages order data.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        // SMO Bug 05 : try not reseting orders list.
        // private readonly List<Order> _orders;
        private static List<Order> _orders;

        public OrderRepository()
        {
            // SMO Bug 05 : Don't reset orders list if already loaded
            // Allow to keep the list of orders confirmed during the user session
            if (_orders == null)
            {
                _orders = new List<Order>();
            }
        }

        /// <summary>
        /// Saves an order.
        /// </summary>
        public void Save(Order order)
        {
            _orders.Add(order);
        }
    }
}