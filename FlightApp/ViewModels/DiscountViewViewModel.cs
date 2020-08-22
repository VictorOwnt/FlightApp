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
        }
    }
}
