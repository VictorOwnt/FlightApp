using FlightAppApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly FlightDbContext _context;
        private readonly DbSet<Product> _products;

        public ProductRepository(FlightDbContext dbContext)
        {
            _context = dbContext;
            _products = dbContext.Products;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;//.Include(p => p.Category);
        }

        public Product GetProductByName(string name)
        {
            return _products.FirstOrDefault(p => p.Name == name);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
