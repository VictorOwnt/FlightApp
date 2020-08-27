using FlightAppApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FlightDbContext _context;
        private readonly DbSet<Order> _orders;

        public OrderRepository(FlightDbContext dbContext)
        {
            _context = dbContext;
            _orders = dbContext.Orders;
        }
        public Order GetOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.OrderId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
