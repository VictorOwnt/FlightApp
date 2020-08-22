using FlightApp.DataService;
using FlightApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.ViewModels
{
    public class DiscountViewViewModel : Prism.Mvvm.BindableBase
    {
        private IEnumerable<Product> _products;
        public IEnumerable<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        private readonly ProductService productService = new ProductService();
        private Dictionary<int, Product> changedProducts = new Dictionary<int, Product>();

        public DiscountViewViewModel()
        {
            SetAllProductsAsync();
        }
        public async void SetAllProductsAsync()
        {
            Products = await productService.GetAllProductsAsync();
        }

        public void SetDiscountPercentage(Product product, double discountPercentage)
        {
            Product ProductToChange = Products.FirstOrDefault(p => p == product);
            ProductToChange.DiscountPercentage = discountPercentage;
            if (!changedProducts.ContainsKey(ProductToChange.ProductId))
            {
                changedProducts.Add(ProductToChange.ProductId, ProductToChange);
            }
            else
            {
                changedProducts[ProductToChange.ProductId] = ProductToChange;
            }

        }

        public void SaveDiscountChanges()
        {
            if (changedProducts.Count() != 0)
            {
                productService.SaveDiscountChanges(changedProducts.Values.ToList());
            }

        }
    }
}
